using Armis.BusinessModels.ProcessModels;
using ArmisWebsite.DataAccess.Process.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Process
{
    public class OperationDataAccess : IOperationDataAccess
    {
        private readonly IConfiguration Config;
        public OperationDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task<IEnumerable<OperationModel>> GetAllOperations()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(Config["APIAddress"] + "api/operation/getalloperations");

                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<OperationModel>>(responseString);

                return result;
            }
        }
    }
}
