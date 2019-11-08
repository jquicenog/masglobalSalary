using System;
using System.Collections.Generic;
using System.Text;

namespace Masglobal.EmployeeSalary.Dal.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EmployeeContractTypeEnum ContractTypeName { get; set; }
        public decimal HourlySalary { get; set; }
        public decimal MonthlySalary { get; set; }
    }
}
