using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.ProcessModels;
using ArmisWebsite.DataAccess.Process.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ArmisWebsite
{
    public class ProcessRevMaintenanceModel : PageModel
    {
        public readonly string _apiAddress; //This is needed whenever javascrit is responsible for loading data from the API.

        //Data Access
        public IProcessDataAccess ProcessDataAccess { get; set; }
        public IStepDataAccess StepDataAccess { get; set; }

        //Model Properties
        public List<ProcessModel> AllProcesses { get; set; }
        public List<StepModel> AllSteps { get; set; }
        public ProcessRevisionModel RevToAdd { get; set; }

        //Page Properties
        [BindProperty]
        public ProcessModel CurrentProcess { get; set; }

        [BindProperty]
        public ProcessRevisionModel CurrentRev { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CurrentProcessId { get; set; }

        public ProcessRevMaintenanceModel(IProcessDataAccess aProcessDataAccess,
                                          IStepDataAccess aStepDataAccess, 
                                          IConfiguration aConfig)//Config is injected only to grab the APIAddress for the javascript calls on the web page.
        {
            ProcessDataAccess = aProcessDataAccess;
            StepDataAccess = aStepDataAccess;
            _apiAddress = aConfig["APIAddress"];
        }

        public async Task<IActionResult> OnGetAsync(int aProcessId = 0, string aMessage = "")
        {
            if (CurrentProcessId != null && aProcessId == 0) { aProcessId = int.Parse(CurrentProcessId); }
            await SetUpProperties(aProcessId);

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            return Page();
        }


        public async Task SetUpProperties(int aProcessId)
        {
            var theProcesses = await ProcessDataAccess.GetAllHydratedProcesses();
            AllProcesses = theProcesses.ToList();

            foreach (var process in AllProcesses)
            {
                process.Revisions.OrderByDescending(i => i.ProcessRevId);
            }

            var theSteps = await StepDataAccess.GetAllHydratedSteps();
            AllSteps = theSteps.ToList();

            CurrentRev = new ProcessRevisionModel();
            CurrentRev.Steps = new List<StepModel>();

            CurrentProcess = new ProcessModel();
            if (aProcessId > 0)
            {
                CurrentProcess = AllProcesses.FirstOrDefault(i => i.ProcessId == aProcessId);
                CurrentRev = CurrentProcess.Revisions.OrderByDescending(i => i.ProcessRevId).FirstOrDefault();
            }
        }
    }
}