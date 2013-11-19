using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace EmployeeAPI.Models
{
    // Simple class for JSON deserialization
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; } 
    }
}