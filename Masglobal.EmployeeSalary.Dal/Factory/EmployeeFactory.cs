using Masglobal.EmployeeSalary.Dal.Contracts;
using Masglobal.EmployeeSalary.Dal.Dtos;
using Masglobal.EmployeeSalary.Dal.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masglobal.EmployeeSalary.Dal.Factory
{
    public class EmployeeFactory:IEmployeeFactory
    {
        public IEmployee CreateEmployee(EmployeeContractTypeEnum contractType)
        {
            switch (contractType)
            {
                case EmployeeContractTypeEnum.HourlySalaryEmployee:
                    return new HourlyEmployee();
                case EmployeeContractTypeEnum.MonthlySalaryEmployee:
                    return new MonthlyEmployee();
                default:
                    throw new ArgumentOutOfRangeException(nameof(contractType), contractType, "Contract type not supported.");
            }
        }
    }
}
