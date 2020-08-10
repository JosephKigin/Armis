using Armis.BusinessModels.EmployeeModels;
using ArmisWebsite.DataAccess;
using ArmisWebsite.DataAccess.Employee.Interfaces;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmployeeDataAccess(IConfiguration aConfig, IHttpContextAccessor aHttpContextAccessor)
        {
            Config = aConfig;
            _httpContextAccessor = aHttpContextAccessor;
        }

        public async Task<EmployeeModel> GetEmployeeById(int id)
        {
            return await DataAccessGeneric.HttpGetRequest<EmployeeModel>(Config["APIAddress"] + "api/Employee/GetEmployeeById/" + id, _httpContextAccessor.HttpContext);
        }
    }
}
