using Masglobal.EmployeeSalary.Dal.Contracts;
using Masglobal.EmployeeSalary.Dal.Model;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace Masglobal.EmployeeSalary.Dal
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployees()
        {
            var setting = ConfigHelper.GetConfig();
            var apiEmployee = setting["apiEmployee"];
            List<Employee> lstEmployees = new List<Employee>();
            var client = new RestClient(string.Format(@"{0}", apiEmployee));
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.Timeout = 120000;
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                // Parse the response body.             
                lstEmployees = JsonConvert.DeserializeObject<List<Employee>>(response.Content.ToString());
            }

            return lstEmployees;
        }
    }
}
