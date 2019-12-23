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
    }
}
