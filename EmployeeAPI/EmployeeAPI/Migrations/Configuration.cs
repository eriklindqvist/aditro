using EmployeeAPI.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace EmployeeAPI.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeAPI.Database.EmployeeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EmployeeAPI.Database.EmployeeContext";
        }

        protected override void Seed(EmployeeAPI.Database.EmployeeContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Employees.AddOrUpdate(e => e.EmployeeId,
                new Employee{EmployeeId=1,CompanyId=1,EmployeeNo=1,FirstName="Adam",LastName="West",Title="Developer",Salary=10000},
                new Employee{EmployeeId=2,CompanyId=2,EmployeeNo=2,FirstName="Bert",LastName="East",Title="Manager",Salary=20000},
                new Employee{EmployeeId=3,CompanyId=3,EmployeeNo=3,FirstName="Chet",LastName="South",Title="Officer",Salary=30000});
        }
    }
}
