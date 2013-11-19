using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeAPI.Tests.Database;
using EmployeeAPI.Controllers;
using System.Linq;
using EmployeeAPI.Models;
using EmployeeAPI.Database;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace EmployeeAPI.Tests.Controllers
{
    [TestClass]
    public class EmployeesControllerTest
    {
        private IEmployeeContext context;
        private EmployeesController controller;

        public EmployeesControllerTest()
        {
            this.context = new EmployeeTestContext();
            context.Employees.Add(new Employee { EmployeeId = 1, CompanyId = 1, EmployeeNo = 100, FirstName = "Adam", LastName = "West", Title = "Developer", Salary = 10000 });
            context.Employees.Add(new Employee { EmployeeId = 2, CompanyId = 2, EmployeeNo = 200, FirstName = "Bert", LastName = "East", Title = "Manager", Salary = 20000 });
            context.Employees.Add(new Employee { EmployeeId = 3, CompanyId = 3, EmployeeNo = 300, FirstName = "Chet", LastName = "South", Title = "Officer", Salary = 30000 });

            this.controller = new EmployeesController(this.context);
        }

        [TestMethod]
        public void GetEmployees()
        {
            var employees = controller.GetEmployees();

            Assert.AreEqual(3, employees.Count());
        }

        [TestMethod]
        public void GetEmployee()
        {
            Employee employee1 = controller.GetEmployee(1);
            
            Assert.AreEqual(employee1.EmployeeNo, 100);
            Assert.AreEqual(employee1.FirstName, "Adam");
            Assert.AreEqual(employee1.Title, "Developer");

            Employee employee2 = controller.GetEmployee(2);

            Assert.AreEqual(employee2.EmployeeNo, 200);
            Assert.AreEqual(employee2.FirstName, "Bert");
            Assert.AreEqual(employee2.Title, "Manager");

            Employee employee3 = controller.GetEmployee(3);

            Assert.AreEqual(employee3.EmployeeNo, 300);
            Assert.AreEqual(employee3.FirstName, "Chet");
            Assert.AreEqual(employee3.Title, "Officer");
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException), "Employee was inappropriately found")]
        public void EmployeeNotFound()
        {
            Employee employee4 = controller.GetEmployee(0);
        }
    }
}
