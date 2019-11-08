using Masglobal.EmployeeSalary.Dal.Contracts;
using Masglobal.EmployeeSalary.Dal.Model;

namespace Masglobal.EmployeeSalary.Dal.Dtos
{
    public class MonthlyEmployee : IEmployee
    {
        public MonthlyEmployee()
        {
            contractTypeName = EmployeeContractTypeEnum.MonthlySalaryEmployee;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public EmployeeContractTypeEnum contractTypeName { get; }
        public decimal HourlySalary { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal AnnualSalary => MonthlySalary * 12;
    }
}
