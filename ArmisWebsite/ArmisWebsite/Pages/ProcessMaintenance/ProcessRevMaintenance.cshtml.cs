using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Message { get; set; }
        public bool IsMessageGood { get; set; }

        [BindProperty]
        public ProcessModel CurrentProcess { get; set; }

        [BindProperty(SupportsGet = true)]
        public ProcessRevisionModel CurrentRev { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentProcessId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentRevId { get; set; }

        [BindProperty]
        [MaxLength(100)]
        public string Comment { get; set; } //Validation is done through javascript on the front-end

        [BindProperty]
        public short EmpNumber { get; set; } //Validation is done through javascript on the front-end

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
            if (CurrentProcessId != 0 && aProcessId == 0) { aProcessId = CurrentProcessId; }
            await SetUpProperties(aProcessId);

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            try
            {
                var response = await ProcessDataAccess.DeleteProcessRevision(CurrentProcessId, CurrentRevId);

                Message = "Revision deleted successfully.";
                IsMessageGood = true;
            }
            catch (Exception ex)
            {
                Message = "Revision was not deleted: " + ex.Message;
                IsMessageGood = false;
            }

            await SetUpProperties(CurrentProcessId);

            return Page();
        }

        public async Task<IActionResult> OnPostRevUp()
        {
            CurrentRev.Comments = Comment;
            CurrentRev.CreatedByEmp = EmpNumber;
            CurrentRev.ProcessId = CurrentProcessId;

            try
            {
                var result = await ProcessDataAccess.RevUp(CurrentRev);
                CurrentRev = result;
                Message = "A new revision has been created.";
                IsMessageGood = true;
            }
            catch (Exception ex)
            {
                Message = "Something went wrong: " + ex.Message;
                IsMessageGood = false;
            }

            await SetUpProperties(CurrentProcessId);
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

            CurrentProcess = new ProcessModel(); //This needs to be created even if there isn't a process being passed in so the front-end doesn't throw a null reference exception when looking for a name.

            CurrentRev = new ProcessRevisionModel(); //This also needs to be created right away so the front-end does throw a null reference exception when loading the current step list.
            CurrentRev.Steps = new List<StepModel>();

            if (aProcessId > 0)
            {
                CurrentProcess = AllProcesses.FirstOrDefault(i => i.ProcessId == aProcessId);
                if (CurrentProcess.Revisions.Any())
                {
                    ModelState.Remove("CurrentRevId"); //The input field wasn't updating when deleting an unlocked revision.  This clears the model state for just this property
                    CurrentRev = CurrentProcess.Revisions.OrderByDescending(i => i.ProcessRevId).FirstOrDefault();
                    if (CurrentRev != null) { CurrentRevId = CurrentRev.ProcessRevId; }
                }
                else
                {
                    ModelState.Remove("CurrentRevId"); //The input field wasn't updating when deleting an unlocked revision.  This clears the model state for just this property
                    CurrentRevId = 0;
                }
            }
        }
    }
}