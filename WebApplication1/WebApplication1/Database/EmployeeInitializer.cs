using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Database
{
    public class EmployeeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EmployeeDbContext>
    {
        protected override void Seed(EmployeeDbContext context)
        {
            var employees = new List<Employee>
            {
                new Employee{EmployeeNo=1,Company=1,FirstName="John",LastName="Doe",Title="System Developer",Salary=10000},
                new Employee{EmployeeNo=2,Company=2,FirstName="Jane",LastName="Roe",Title="Project Owner",Salary=20000},
                new Employee{EmployeeNo=3,Company=3,FirstName="Jack",LastName="Moe",Title="CEO",Salary=30000}
            };

            employees.ForEach(employee => context.Employees.Add(employee));
            context.SaveChanges();
        }
    }
}