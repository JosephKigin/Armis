using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ArmisWebsite.Pages.Shared.Components
{
    public class ApiConnectionCheckViewComponent : ViewComponent
    {
        public IConfiguration Config { get; set; }
        public bool CanConnectToApi { get; set; }

        public ApiConnectionCheckViewComponent(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {


            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(Config["APIAddress"] + "index");
                    if (response.IsSuccessStatusCode) { CanConnectToApi = true; }
                    else { CanConnectToApi = false; }
                }
            }
            catch (Exception)
            {
                CanConnectToApi = false;
            }

            return View(CanConnectToApi);
        }
    }
}
