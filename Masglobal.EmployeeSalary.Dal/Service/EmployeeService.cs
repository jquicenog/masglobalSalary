using Masglobal.EmployeeSalary.Dal.Contracts;
using Masglobal.EmployeeSalary.Dal.Model;
using System.Collections.Generic;
using System.Linq;

namespace Masglobal.EmployeeSalary.Dal.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeFactory _employeeFactory;

        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeFactory employeeFactory)
        {
            _employeeRepository = employeeRepository;
            _employeeFactory = employeeFactory;
        }

        public IEnumerable<IEmployee> GetEmployees()
        {
            var employees = _employeeRepository.GetEmployees();
            return employees.Select(x=>MapToEmployee(x));
        }

        public IEmployee GetEmployeeById(int id)
        {
            var employees = _employeeRepository.GetEmployees();
            var employee = employees.Where(x=>x.Id==id).FirstOrDefault();
            return employee != null ? MapToEmployee(employee) : null;
        }

        private IEmployee MapToEmployee(Employee employee)
        {
            var mapEmployee = _employeeFactory.CreateEmployee(employee.ContractTypeName);
            mapEmployee.Id = employee.Id;
            mapEmployee.Name = employee.Name;
            mapEmployee.HourlySalary = employee.HourlySalary;
            mapEmployee.MonthlySalary = employee.MonthlySalary;

            return mapEmployee;
        }
    }
}
