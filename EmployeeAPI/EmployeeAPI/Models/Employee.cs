using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace EmployeeAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        
        [JsonIgnore] // Do not display in JSON
        [IgnoreDataMember] // Do not display in XML        
        public int CompanyId { get; set; }
        
        public int EmployeeNo { get; set; }

        [Required] // Not null. Strings are nullable by default
        public string FirstName { get; set; }

        [Required] // Not null
        public string LastName { get; set; }

        [Required] // Not null
        public string Title { get; set; }

        public decimal Salary { get; set; }

        [NotMapped] // Do not create column in DB
        public string Company
        {
            get
            {
                try
                {
                    var json = new WebClient().DownloadString("http://novacompanysvc.azurewebsites.net/api/companies/" + CompanyId);
                    var company = jsonToCompany(json);
                    return company.Name;
                }
                catch (WebException e)
                {
                    HttpWebResponse response = (HttpWebResponse)e.Response;

                    // If requested company does not exist, return empty string.
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        this.Error = response.StatusDescription;
                        return "";
                    }

                    // Otherwise something worse went wrong. Re-throw the exception.
                    throw e;
                }
            }

            set { } // Trick the XML serializer to include the Company field
        }

        [NotMapped] // Do not create column in DB
        public string Error { get; set; }
        
        private Company jsonToCompany(string json)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Company));
            
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                return (Company) serializer.ReadObject(ms);
            }
        }
    }
}