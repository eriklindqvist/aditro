using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeAPI.Tests.Database
{
    class EmployeeTestDbSet : TestDbSet<Employee>
    {
        public override Employee Find(params object[] keyValues)
        {
            return this.SingleOrDefault(e => e.EmployeeId == (int)keyValues.FirstOrDefault());
        }
    }
}
