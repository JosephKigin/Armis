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

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<List<OperationModel>>(responseString);

                    return result;
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }
        }

        public async Task<IEnumerable<OperationGroupModel>> GetAllOperationGroups()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(Config["APIAddress"] + "api/operation/GetAllOperationGroups");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<List<OperationGroupModel>>(responseString);

                    return result;
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }
        }

        public async Task<OperationModel> CreateOperation(OperationModel anOperationModel)
        {
            using(var client = new HttpClient())
            {
                var data = new StringContent(JsonSerializer.Serialize(anOperationModel), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Config["APIAddress"] + "api/operation/CreateOperation", data);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<OperationModel>(responseString);

                    return result;
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }
        }

        public async Task<OperationModel> UpdateOperation(OperationModel anOperationModel)
        {
            using (var client = new HttpClient())
            {
                var data = new StringContent(JsonSerializer.Serialize(anOperationModel), Encoding.UTF8, "application/json");
                var response = await client.PutAsync(Config["APIAddress"] + "api/operation/UpdateOperation", data);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<OperationModel>(responseString);

                    return result;
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }
        }
    }
}
