using Armis.BusinessModels.ProcessModels;
using ArmisWebsite.DataAccess.Process.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmisWebsite
{
    public class ProcessListingModel : PageModel
    {
        //Data Access
        public IProcessDataAccess ProcessDataAccess { get; set; }

        //Models
        public List<ProcessModel> Processes { get; set; }

        //Front-End

        public ProcessListingModel(IProcessDataAccess aProcessDataAccess)
        {
            ProcessDataAccess = aProcessDataAccess;
        }

        public async Task<IActionResult> OnGet()
        {
            await SetUpPage();

            return Page();
        }

        public async Task SetUpPage()
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