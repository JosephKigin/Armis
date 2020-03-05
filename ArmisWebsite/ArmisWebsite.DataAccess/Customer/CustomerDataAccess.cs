using Armis.BusinessModels.Customer;
using ArmisWebsite.DataAccess.Customer.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq;

namespace ArmisWebsite.DataAccess.Customer
{
    public class CustomerDataAccess : ICustomerDataAccess
    {
        private readonly IConfiguration Config;

        public CustomerDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task<IEnumerable<CustomerModel>> GetAllCustomers()
        {
            using (var client = new HttpClient())
            {

                var response = await client.GetAsync(Config["APIAddress"] + "api/Customers/GetCustomers");

                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<CustomerModel>>(responseString);
                var sortedResult = result.OrderBy(i => i.Name);

                return sortedResult;

            }
        }
    }
}
