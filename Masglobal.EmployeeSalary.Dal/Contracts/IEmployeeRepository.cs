using Masglobal.EmployeeSalary.Dal.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masglobal.EmployeeSalary.Dal.Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
    }
}
