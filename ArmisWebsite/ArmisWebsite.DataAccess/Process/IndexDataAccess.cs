using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ArmisWebsite.DataAccess;
using ArmisWebsite.DataAccess.Process.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ArmisWebsite.DataAccess.Process
{
    public class IndexDataAccess : IIndexDataAccess
    {
        private readonly IConfiguration Config;

        public IndexDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task<bool> CheckApiConntection()
        {
            
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(Config["APIAddress"] + "index");
                    if (!response.IsSuccessStatusCode) { throw new Exception(response.ReasonPhrase + ": " + await response.Content.ReadAsStringAsync()); }
                }
                return true; //if the above request doesn't error out, the website is connecting to the API correctly.
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
