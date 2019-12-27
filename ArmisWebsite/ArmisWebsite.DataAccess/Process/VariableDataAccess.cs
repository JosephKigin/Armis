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
    public class VariableDataAccess : IVariableDataAccess
    {
        public async Task<IEnumerable<VariableTemplateModel>> GetAllTemplates()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync("https://localhost:44316/api/stepvartemplates/GetAllStepVarTemplates"); //TODO: Move this to config.

                    var responseString = await response.Content.ReadAsStringAsync();
                    var resultStringJson = JsonSerializer.Deserialize<List<VariableTemplateModel>>(responseString);
                    return resultStringJson;

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
                    var response = await client.GetAsync("https://localhost:44316/api/stepvartypes"); //TODO: Move this to config.

                    var responseString = await response.Content.ReadAsStringAsync();
                    var resultStringJson = JsonSerializer.Deserialize<List<VariableTypeModel>>(responseString);
                    return resultStringJson;

                }
                catch (Exception ex) { throw new Exception(ex.Message); }
            }
        }

        public async Task<HttpResponseMessage> PostVariableTemplate(VariableTemplateModel aVariableTemplateModel)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    StringContent data = new StringContent(JsonSerializer.Serialize(aVariableTemplateModel), Encoding.UTF8, "application/json");
                    var doesItReturnSomething = await client.PostAsync("https://localhost:44316/api/StepVarTemplates", data); //TODO: Move this to config.

                    return doesItReturnSomething;
                }
                catch (Exception ex) { throw new Exception(ex.Message); }
            }
        }
    }
}
