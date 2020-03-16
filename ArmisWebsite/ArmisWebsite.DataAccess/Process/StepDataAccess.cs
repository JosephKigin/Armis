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
        public IDataAccessGeneric DataAccessGeneric { get; set; }

        public StepDataAccess(IConfiguration aConfig, IDataAccessGeneric aDataAccessGeneric)
        {
            Config = aConfig;
            DataAccessGeneric = aDataAccessGeneric;
        }

        public async Task<int> PostNewStep(StepModel aStepModel)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    StringContent data = new StringContent(JsonSerializer.Serialize(aStepModel), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(Config["APIAddress"] + "api/Steps/PostStep/", data);

                    var responseString = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<int>(responseString);

                    return result;
                }
                catch (Exception ex) { throw new Exception(ex.Message); } //TOODO: Error handle better
            }
        }

        public async Task<IEnumerable<StepModel>> GetAllSteps()
        {
            
            
                var resultingModels = JsonSerializer.Deserialize<List<StepModel>>(await DataAccessGeneric.HttpGetRequest("api/Steps/GetAllSteps"));
                var result = resultingModels.OrderBy(i => i.StepId).ToList();
                return result;
            
            //(Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<IEnumerable<StepCategoryModel>> GetAllStepCategoryies()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(Config["APIAddress"] + "api/Steps/GetAllStepCategories");

                    //if(response.StatusCode == System.Net.HttpStatusCode.BadRequest) { throw new Exception("Bad Request: " + response); }

                    var responseString = await response.Content.ReadAsStringAsync();
                    var resultingModels = JsonSerializer.Deserialize<List<StepCategoryModel>>(responseString);

                    return resultingModels;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<StepCategoryModel> GetStepCategoryByCode(string aStepCategoryCode)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(Config["APIAddress"] + "api/Steps/GetStepCategoryByCode/" + aStepCategoryCode);

                    //if(response.StatusCode == System.Net.HttpStatusCode.BadRequest) { throw new Exception("Bad Request: " + response); }

                    var responseString = await response.Content.ReadAsStringAsync();
                    var resultingModels = JsonSerializer.Deserialize<StepCategoryModel>(responseString);

                    return resultingModels;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<StepModel> GetStepById(int aStepId)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(Config["APIAddress"] + "api/Steps/GetStepById/" + aStepId);

                    var responseString = await response.Content.ReadAsStringAsync();
                    var resultingModel = JsonSerializer.Deserialize<StepModel>(responseString);

                    return resultingModel;
                }
                catch (Exception ex) { throw new Exception(ex.Message); } //TOODO: Error handle better
            }
        }

        public async Task<List<StepModel>> GetStepByName(string aStepName)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(Config["APIAddress"] + "api/Steps/GetStepByName/" + aStepName);

                    var responseString = await response.Content.ReadAsStringAsync();
                    var resultingModel = JsonSerializer.Deserialize<List<StepModel>>(responseString);

                    return resultingModel;
                }
                catch (Exception ex) { throw new Exception(ex.Message); } //TOODO: Error handle better
            }
        }
    }
}
