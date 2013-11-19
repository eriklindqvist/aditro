using EmployeeAPI.Database;
using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Tests.Database
{
    class EmployeeTestContext : IEmployeeContext
    {
        public EmployeeTestContext()
        {
            this.Employees = new EmployeeTestDbSet();
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
