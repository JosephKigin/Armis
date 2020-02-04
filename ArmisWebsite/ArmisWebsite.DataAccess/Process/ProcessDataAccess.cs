using Armis.BusinessModels.ProcessModels;
using ArmisWebsite.DataAccess.Process.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace ArmisWebsite.DataAccess.Process
{
    public class ProcessDataAccess : IProcessDataAccess
    {
        private readonly IConfiguration Config;
        public ProcessDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task<IEnumerable<ProcessModel>> GetAllProcesses()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(Config["APIAddress"] + "api/Processes/GetProcess");

                    var responseString = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<List<ProcessModel>>(responseString);

                    return result;
                }
                catch (Exception ex)
                {
                    throw; //TODO: Implement better error handling
                }
            }
        }

        public async Task<IEnumerable<ProcessModel>> GetAllHydratedProcesses()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(Config["APIAddress"] + "api/Processes/GetHydratedProcesses");

                    var responseString = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<List<ProcessModel>>(responseString);

                    return result;
                }
                catch (Exception ex)
                {
                    throw; //TODO: Implement better error handling
                }
            }
        }
    }
}
