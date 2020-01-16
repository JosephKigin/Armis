using Armis.BusinessModels.ProcessModels;
using ArmisWebsite.DataAccess.Process.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Process
{
    public class StepDataAccess : IStepDataAccess
    {
        private readonly IConfiguration Config;

        public StepDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task<int> PostNewStep(StepModel aStepModel)
        {
            using(var client = new HttpClient())
            {
                try
                {
                    StringContent data = new StringContent(JsonSerializer.Serialize(aStepModel), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(Config["APIAddress"] + "api/Steps", data); //TODO: Move this to config

                    var responseString = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<int>(responseString);

                    return result;
                }
                catch(Exception ex) { throw new Exception(ex.Message); } //TOODO: Error handle better
            }
        }

        public async Task<int> AddVariablesToStep(StepModel aStepModel)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    StringContent data = new StringContent(JsonSerializer.Serialize(aStepModel), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(Config["APIAddress"] + "api/Steps/PostVariablesToStep", data);

                    var responseString = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<int>(responseString);

                    return result;
                }
                catch (Exception ex)
                {

                    throw; //TODO: Error handle gooder...
                }
            }
        }

        public async Task<IEnumerable<StepModel>> GetAllHydratedSteps()
        {
            using(var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(Config["APIAddress"] + "api/Steps"); //TODO: Move this to config.

                    var responseString = await response.Content.ReadAsStringAsync();
                    var resultingModels = JsonSerializer.Deserialize<List<StepModel>>(responseString);
                    var result = resultingModels.OrderBy(i => i.StepId).ToList();
                    return result;
                }
                catch (Exception ex) { throw new Exception(ex.Message); } //TOODO: Error handle better
            }
        }

        public async Task<StepModel> GetStepById(int aStepId)
        {
            using(var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(Config["APIAddress"] + "api/Steps/" + aStepId);

                    var responseString = await response.Content.ReadAsStringAsync();
                    var resultingModel = JsonSerializer.Deserialize<StepModel>(responseString);

                    return resultingModel;
                }
                catch(Exception ex) { throw new Exception(ex.Message); }
            }
        }
    }
}
