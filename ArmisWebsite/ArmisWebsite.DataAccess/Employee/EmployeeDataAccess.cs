using Armis.BusinessModels.EmployeeModels;
using ArmisWebsite.DataAccess;
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

        public async Task<EmployeeModel> GetEmployeeById(int id)
        {
            return await DataAccessGeneric.HttpGetRequest<EmployeeModel>(Config["APIAddress"] + "api/Employee/GetEmployeeById/" + id);
        }
    }
}
