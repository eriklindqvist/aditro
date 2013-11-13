using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Database
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext() : base("EmployeeContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}