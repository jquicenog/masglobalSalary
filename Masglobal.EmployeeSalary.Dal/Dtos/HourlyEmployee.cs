using Masglobal.EmployeeSalary.Dal.Contracts;
using Masglobal.EmployeeSalary.Dal.Model;

namespace Masglobal.EmployeeSalary.Dal.Dtos
{
    public class HourlyEmployee : IEmployee
    {
        public HourlyEmployee()
        {
            contractTypeName = EmployeeContractTypeEnum.HourlySalaryEmployee;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public EmployeeContractTypeEnum contractTypeName { get; }
        public decimal HourlySalary { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal AnnualSalary => 120 * HourlySalary * 12;
    }
}
