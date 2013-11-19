using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Database
{
    public interface IEmployeeContext
    {
        DbSet<Employee> Employees { get; }
    }
}
