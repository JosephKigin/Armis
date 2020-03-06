using Armis.BusinessModels.EmployeeModels;
using ArmisWebsite.DataAccess.Employee.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Employee
{
    public class EmployeeDataAccess : IEmployeeDataAccess
    {
        private readonly IConfiguration Config;

        public EmployeeDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task<EmployeeModel> GetEmployeeById(short id)
        {
            using (var client = new HttpClient())
            {
                //Add status catch and this isnt finding the correct api path
                var response = await client.GetAsync(Config["APIAddress"] + "api/Employee/GetEmployeeById/" + id);

                var responseString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<EmployeeModel>(responseString);
            }
        }
    }
}
