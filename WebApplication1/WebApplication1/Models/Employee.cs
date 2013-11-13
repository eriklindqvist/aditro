using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }  // TODO: Primary key! Hur gör EF???
        public int Company { get; set; }
        public int EmployeeNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public decimal Salary { get; set; }
    }
}