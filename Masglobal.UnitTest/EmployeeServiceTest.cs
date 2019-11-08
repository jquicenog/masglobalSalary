using Masglobal.EmployeeSalary.Dal.Contracts;
using Masglobal.EmployeeSalary.Dal.Dtos;
using Masglobal.EmployeeSalary.Dal.Factory;
using Masglobal.EmployeeSalary.Dal.Model;
using Masglobal.EmployeeSalary.Dal.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Masglobal.UnitTest
{
    [TestClass]
    public class EmployeeServiceTest
    {
        [TestMethod]
        public void AnnualSalaryCalculated_WhenTheEmployeeHasHourlyContract()
        {
            //formula to calculate annual salary to HourlyEmployee 120 * HourlySalary * 12
            //Arrange
            const decimal annualSalaryExpected = 11520;
            var hourlyEmployee = new HourlyEmployee
            {
                Id = 1,
                Name = "Jhonatan",
                HourlySalary = 8
            };
            //Assert
            Assert.AreEqual(hourlyEmployee.AnnualSalary, annualSalaryExpected);
        }

        [TestMethod]
        public void SuccessGettingEmployees()
        {

            //Arrange
            var employees = GetFakeEmployees();
            var employeesRepository = new Mock<IEmployeeRepository>();
            employeesRepository.Setup(repo => repo.GetEmployees()).Returns(employees);

            var expectedListResponse = new List<IEmployee>
            {
                new HourlyEmployee() {Id = 1, HourlySalary = 6000, MonthlySalary = 8000, Name = "Juan"},
                new MonthlyEmployee() {Id = 2, HourlySalary = 6000, MonthlySalary = 8000, Name = "Sebastian"}
            };

            var employeeService = new EmployeeService(employeesRepository.Object, new EmployeeFactory());

            //Act
            var responseListOfEmployees = employeeService.GetEmployees();

            //Assert

            Assert.AreEqual(responseListOfEmployees.Count(), expectedListResponse.Count);
            Assert.AreEqual(responseListOfEmployees.FirstOrDefault().Id, expectedListResponse.FirstOrDefault().Id);
            Assert.AreEqual(responseListOfEmployees.FirstOrDefault().Name, expectedListResponse.FirstOrDefault().Name);
            Assert.AreEqual(responseListOfEmployees.LastOrDefault().Id, expectedListResponse.LastOrDefault().Id);
            Assert.AreEqual(responseListOfEmployees.LastOrDefault().Name, expectedListResponse.LastOrDefault().Name);
        }

        [TestMethod]
        public void SuccessGettingEmployeesById()
        {
            //Arrange
            var employees = GetFakeEmployees();
            var employeesRepository = new Mock<IEmployeeRepository>();
            employeesRepository.Setup(repo => repo.GetEmployees()).Returns(employees);

            var expectedResponse = new HourlyEmployee()
            {
                Id = 1,
                HourlySalary = 6000,
                MonthlySalary = 8000,
                Name = "Juan"
            };

            var employeeService = new EmployeeService(employeesRepository.Object, new EmployeeFactory());

            //Act
            var responseEmployee = employeeService.GetEmployeeById(1);

            //Assert
            Assert.AreEqual(responseEmployee.Id, expectedResponse.Id);
            Assert.AreEqual(responseEmployee.Name, expectedResponse.Name);
        }

        private static List<Employee> GetFakeEmployees()
        {
            return new List<Employee>
            {
                new Employee {Id = 1, Name="Juan",ContractTypeName = EmployeeContractTypeEnum.HourlySalaryEmployee,  HourlySalary = 60000, MonthlySalary = 8000},
                new Employee {Id = 2, Name="Sebastian", ContractTypeName = EmployeeContractTypeEnum.MonthlySalaryEmployee, HourlySalary = 60000, MonthlySalary = 8000}
            };
        }
    }
}
