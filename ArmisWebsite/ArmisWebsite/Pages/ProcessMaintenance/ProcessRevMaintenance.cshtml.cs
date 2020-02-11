using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.ProcessModels;
using ArmisWebsite.DataAccess.Process.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArmisWebsite
{
    public class ProcessRevMaintenanceModel : PageModel
    {
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

        public ProcessRevMaintenanceModel(IProcessDataAccess aProcessDataAccess, IStepDataAccess aStepDataAccess)
        {
            ProcessDataAccess = aProcessDataAccess;
            StepDataAccess = aStepDataAccess;
        }

        public async Task<IActionResult> OnGetAsync(int aProcessId = 0, string aMessage = "")
        {
            if(CurrentProcessId != null && aProcessId == 0) { aProcessId = int.Parse(CurrentProcessId); }
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