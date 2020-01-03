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
    public class UOMCodeDataAccess : IUOMCodeDataAccess
    {
        private readonly IConfiguration Config;

        public UOMCodeDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task<IEnumerable<UOMCodeModel>> GetAllUOMCodes()
        {
            using(var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(Config["APIAddress"] + "api/UOMcodes");

                    var responseString = await response.Content.ReadAsStringAsync();
                    var resultStringJson = JsonSerializer.Deserialize<List<UOMCodeModel>>(responseString);
                    return resultStringJson;

                }
                catch (Exception ex) { throw new Exception(ex.Message); }
            }
        }
    }
}
