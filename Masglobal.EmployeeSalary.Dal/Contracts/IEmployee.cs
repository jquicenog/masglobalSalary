using Masglobal.EmployeeSalary.Dal.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masglobal.EmployeeSalary.Dal.Contracts
{
    public interface IEmployee
    {
        int Id { get; set; }
        string Name { get; set; }
        EmployeeContractTypeEnum contractTypeName { get; }
        decimal HourlySalary { get; set; }
        decimal MonthlySalary { get; set; }
        decimal AnnualSalary { get; }
    }
}
