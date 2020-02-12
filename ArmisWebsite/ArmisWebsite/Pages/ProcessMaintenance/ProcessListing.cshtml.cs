using Armis.BusinessModels.ProcessModels;
using ArmisWebsite.DataAccess.Process.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmisWebsite
{
    public class ProcessListingModel : PageModel
    {
        public readonly string _apiAddress; //This is needed whenever javascrit is responsible for loading data from the API.
        //Data Access
        public IProcessDataAccess ProcessDataAccess { get; set; }

        //Models
        public List<ProcessModel> Processes { get; set; }

        //Front-End

        public ProcessListingModel(IProcessDataAccess aProcessDataAccess, IConfiguration aConfig) //Config is injected only to grab the APIAddress for the javascript calls on the web page.
        {
            ProcessDataAccess = aProcessDataAccess;
            _apiAddress = aConfig["APIAddress"];
        }

        public async Task<IActionResult> OnGet()
        {
            await SetUpProperties();

            return Page();
        }

        public async Task SetUpProperties()
        {
            var theProcesses = await ProcessDataAccess.GetAllProcesses();
            Processes = theProcesses.ToList();

            foreach (var process in Processes)
            {
                process.Revisions.OrderBy(i => i.ProcessRevId);
            }
        }
    }
}