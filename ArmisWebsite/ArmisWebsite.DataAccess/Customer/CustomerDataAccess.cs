using Armis.BusinessModels.Customer;
using ArmisWebsite.DataAccess;
using ArmisWebsite.DataAccess.Customer.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace ArmisWebsite.DataAccess.Customer
{
    public class CustomerDataAccess : ICustomerDataAccess
    {
        private readonly IConfiguration Config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerDataAccess(IConfiguration aConfig, IHttpContextAccessor aHttpContextAccessor)
        {
            Config = aConfig;
            _httpContextAccessor = aHttpContextAccessor;
        }

        public async Task<IEnumerable<CustomerModel>> GetAllCustomers()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<CustomerModel>>(Config["APIAddress"] + "api/Customers/GetCustomers", _httpContextAccessor.HttpContext);
        }

        public async Task<IEnumerable<CustomerModel>> GetAllCurrentAndProspectCustomers()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<CustomerModel>>(Config["APIAddress"] + "api/Customers/GetAllCurrentAndProspectCustomers", _httpContextAccessor.HttpContext);
        }
    }
}
