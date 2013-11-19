using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EmployeeAPI.Models;
using EmployeeAPI.Database;

namespace EmployeeAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        private IEmployeeContext context;

        public EmployeesController()
        {
            this.context = new EmployeeContext();
        }

        public EmployeesController(IEmployeeContext context)
        {
            this.context = context;
        }

        // GET api/Employees
        public IQueryable<Employee> GetEmployees()
        {
            return context.Employees;
        }

        // GET api/Employees/5
        public Employee GetEmployee(int id)
        {
            var employee = this.context.Employees.Find(id);
            
            if (employee == null)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent("Employee not found")
                });
            }

            return employee;
        }
    }
}