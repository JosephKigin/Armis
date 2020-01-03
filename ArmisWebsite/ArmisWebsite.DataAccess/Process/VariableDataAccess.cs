using Armis.BusinessModels.ProcessModels;
using ArmisWebsite.DataAccess.Process.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace ArmisWebsite.DataAccess.Process
{
    public class VariableDataAccess : IVariableDataAccess
    {
        private readonly IConfiguration Config;

        public VariableDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task<IEnumerable<VariableTemplateModel>> GetAllTemplates()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(Config["APIAddress"] + "api/stepvartemplates/GetAllStepVarTemplates"); //TODO: Move this to config.

                    var responseString = await response.Content.ReadAsStringAsync();
                    var resultingModels = JsonSerializer.Deserialize<List<VariableTemplateModel>>(responseString);
                    var result = resultingModels.OrderBy(i => i.Name).ToList();
                    return result;

                }
                catch (Exception ex) { throw new Exception(ex.Message); }
            }
        }

        public async Task<IEnumerable<VariableTypeModel>> GetAllVarTypes()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(Config["APIAddress"] + "api/stepvartypes"); //TODO: Move this to config.

                    var responseString = await response.Content.ReadAsStringAsync();
                    var resultingModels = JsonSerializer.Deserialize<List<VariableTypeModel>>(responseString);
                    return resultingModels;

                }
                catch (Exception ex) { throw new Exception(ex.Message); } //TODO: error handle better
            }
        }

        public async Task<HttpResponseMessage> PostVariableTemplate(VariableTemplateModel aVariableTemplateModel)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    StringContent data = new StringContent(JsonSerializer.Serialize(aVariableTemplateModel), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(Config["APIAddress"] + "api/StepVarTemplates", data); //TODO: Move this to config.

                    return response;
                }
                catch (Exception ex) { throw new Exception(ex.Message); } //TODO: Error handle better
            }
        }
    }
}
