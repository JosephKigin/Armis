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
    public class ProcessMaintenanceModel : PageModel
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

        [BindProperty]
        public int TempProcessRevId { get; set; }

        public ProcessMaintenanceModel(IProcessDataAccess aProcessDataAccess, IStepDataAccess aStepDataAccess)
        {
            ProcessDataAccess = aProcessDataAccess;
            StepDataAccess = aStepDataAccess;
        }

        public async Task<IActionResult> OnGet(int aProcessId = 0, string aMessage = "")
        {
            await SetUpProperties();

            CurrentRev = new ProcessRevisionModel();
            CurrentRev.Steps = new List<StepModel>();

            if (aProcessId != 0)
            {
                CurrentProcess = AllProcesses.FirstOrDefault(i => i.ProcessId == aProcessId);
                CurrentRev = CurrentProcess.Revisions.OrderByDescending(i => i.ProcessRevId).FirstOrDefault();
            }

            return Page();
        }

        public async Task SetUpProperties()
        {
            var theProcesses = await ProcessDataAccess.GetAllHydratedProcesses();
            AllProcesses = theProcesses.ToList();

            var theSteps = await StepDataAccess.GetAllHydratedSteps();
            AllSteps = theSteps.ToList();
        }
    }
}