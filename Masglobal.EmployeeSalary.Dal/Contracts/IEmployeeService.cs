using Masglobal.EmployeeSalary.Dal.Model;
using System.Collections.Generic;

namespace Masglobal.EmployeeSalary.Dal.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<IEmployee> GetEmployees();
        IEmployee GetEmployeeById(int id);
    }
}
