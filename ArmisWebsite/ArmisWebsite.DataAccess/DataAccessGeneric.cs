using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess
{
    public class DataAccessGeneric : IDataAccessGeneric
    {
        private readonly IConfiguration Config;

        public DataAccessGeneric(IConfiguration aConfig)
        {
            Config = aConfig;

        }

        public async Task<string> HttpGetRequest(string aPath)
        {
            using(var client = new HttpClient())
            {
                var response = await client.GetAsync(Config["APIAddress"] + aPath);
                if (!response.IsSuccessStatusCode) { throw new Exception(response.ReasonPhrase + ": " + await response.Content.ReadAsStringAsync()); }
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
