using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArmisWebsite.DataAccess.Process;
using ArmisWebsite.DataAccess.Process.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArmisWebsite.Pages.Shared.Partials
{
    public class ApiCheckConnectionPartialModel : PageModel
    {
        public IApiCheckConnectionDataAccess IndexDataAccess { get; set; }
        public bool CanConnectToApi { get; set; }

        public ApiCheckConnectionPartialModel()
        {
            //Dependency injection and layout and this partial and api check connection data acccess are not playing nice.
        }

        public async void OnGet()
        {
            //CanConnectToApi = await IndexDataAccess.CheckApiConntection();
        }
    }
}