using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Armis.BusinessModels.EmployeeModels;
using Armis.BusinessModels.ProcessModels;
using ArmisWebsite.DataAccess.Employee.Interfaces;
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
        public IOperationDataAccess OperationDataAccess { get; set; }
        public IEmployeeDataAccess EmployeeDataAccess { get; set; }

        //Model Properties
        public List<ProcessModel> AllProcesses { get; set; }
        public List<StepModel> AllSteps { get; set; }
        public List<OperationModel> AllOperations { get; set; }
        public List<OperationModel> CurrentOperations { get; set; }
        public ProcessRevisionModel RevToAdd { get; set; }
        public EmployeeModel EmpCreatedCurrentRev { get; set; }


        //Page Properties
        public string PopUpMessage { get; set; }
        public int InitialStepSeq { get; set; }

        [BindProperty]
        public List<int> CurrentStepIds { get; set; }

        [BindProperty]
        public List<int> CurrentOperationIds { get; set; }

        [BindProperty]
        public ProcessModel CurrentProcess { get; set; }

        [BindProperty(SupportsGet = true)]
        public ProcessRevisionModel CurrentRev { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentProcessId { get; set; }

        [BindProperty]
        public int SelectedProcessId { get; set; } //TODO: Is this even used anywhere?

        [BindProperty(SupportsGet = true)]
        public int CurrentRevId { get; set; }

        [BindProperty]
        [MaxLength(100)]
        public string Comment { get; set; } //Validation is done through javascript on the front-end

        [BindProperty]
        public short EmpNumber { get; set; } //Validation is done through javascript on the front-end

        [BindProperty]
        public string NewProcessName { get; set; }


        public ProcessRevMaintenanceModel(IProcessDataAccess aProcessDataAccess,
                                          IStepDataAccess aStepDataAccess,
                                          IOperationDataAccess anOperationDataAccess,
                                          IEmployeeDataAccess anEmployeeDataAccess,
                                          IConfiguration aConfig)//Config is injected only to grab the APIAddress for the javascript calls on the web page.
        {
            ProcessDataAccess = aProcessDataAccess;
            StepDataAccess = aStepDataAccess;
            OperationDataAccess = anOperationDataAccess;
            EmployeeDataAccess = anEmployeeDataAccess;
            _apiAddress = aConfig["APIAddress"];
        }

        //General page start up method.  If an Id is passed in, then the page will load the most current rev for that Id and populate the page based on if that revision is "LOCKED" or "UNLOCKED".
        public async Task<IActionResult> OnGetAsync() //TODO: Both the page loading empty and the page loading with a processId go through this onget.  Seperate those to different ongets.
        {
            try
            {
               var aProcessId = 0; //This just exists to make the logic on the next line easier to understand and cleaner to pass into SetUpProperties.
               if (SelectedProcessId != 0) { CurrentProcessId = SelectedProcessId; }
               if (CurrentProcessId != 0) { aProcessId = CurrentProcessId; }
                
                await SetUpProperties(aProcessId);

                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error", new { ExMessage = "Could not set up Process Rev Maintenance page." + ex.Message });
            }
        }

        public async Task<IActionResult> OnPost() //This should never be hit.  It is here for testing purposes.
        {
            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            try
            {
                var response = await ProcessDataAccess.DeleteProcessRevision(CurrentProcessId, CurrentRevId);

                PopUpMessage = "Revision deleted successfully.";
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error", new { ExMessage = "There was a problem deleting that revision. " + ex.Message});
            }

            try
            {
                await SetUpProperties(CurrentProcessId);

                return Page();
            }
            catch (Exception)
            {
                return RedirectToPage("/Error", new { ExMessage = "Revision was deleted but could not set up Process Rev Maintenance page." });
            }

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
                PopUpMessage += "A new revision has been created.";
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error", new { ExMessage = "Something went wrong while creating a new revision. " + ex.Message });
            }

            await SetUpProperties(CurrentProcessId);
            return Page();
        }

        public async Task<IActionResult> OnPostSave()
        {
            try
            {
                var theStepSeqList = new List<StepSeqModel>();

                for (int i = 0; i < CurrentStepIds.Count; i++)
                {
                    theStepSeqList.Add(new StepSeqModel
                    {
                        StepId = CurrentStepIds[i],
                        OperationId = CurrentOperationIds[i],
                        Sequence = Convert.ToInt16(i + 1),
                        ProcessId = CurrentProcessId,
                        RevisionId = CurrentRevId
                    });
                }

                var theReturnRevModel = await ProcessDataAccess.SaveStepSeqToRevision(theStepSeqList);

                await SetUpProperties(theReturnRevModel.ProcessId);

                PopUpMessage += "Process saved successfully.";

                return Page();
            }
            catch (Exception ex)
            {

                return RedirectToPage("/Error", new { ExMessage = "Could not update revision. " + ex.Message });
            }
        }

        public async Task<IActionResult> OnPostLock()
        {
            try
            {
                var theStepSeqList = new List<StepSeqModel>();

                for (int i = 0; i < CurrentStepIds.Count; i++)
                {
                    theStepSeqList.Add(new StepSeqModel
                    {
                        StepId = CurrentStepIds[i],
                        OperationId = CurrentOperationIds[i],
                        Sequence = Convert.ToInt16(i + 1),
                        ProcessId = CurrentProcessId,
                        RevisionId = CurrentRevId
                    });
                }

                var theReturnRevModel = await ProcessDataAccess.LockRevision(CurrentProcessId, CurrentRevId, theStepSeqList);

                await SetUpProperties(theReturnRevModel.ProcessId);

                PopUpMessage += "Revision was locked successfully. ";

                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error", new { ExMessage = "Something went wrong while locking the revision. " + ex.Message });
            }

        }

        public async Task<IActionResult> OnPostCopy()
        {
            try
            {
                CurrentProcess.ProcessId = CurrentProcessId;
                CurrentProcess.Name = NewProcessName;
                CurrentRev.Comments = Comment;
                CurrentRev.CreatedByEmp = EmpNumber;
                var tempRevList = new List<ProcessRevisionModel>(); //This only exists to add the current rev to and then to be assigned to the currentProcess.revisions becasue its an IEnumerable
                tempRevList.Add(CurrentRev);
                CurrentProcess.Revisions = tempRevList;
                var result = await ProcessDataAccess.CopyToNewProcessFromExisting(CurrentProcess);

                ModelState.Remove("CurrentProcessId");

                await SetUpProperties(result.ProcessId);
                CurrentProcessId = result.ProcessId;
                PopUpMessage += "Process was successfully copied.";
                return new PageResult();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error", new { ExMessage = "Something went wrong while copying the process. " + ex.Message });
            }
        }

        public async Task SetUpProperties(int aProcessId)
        {
            var theProcesses = await ProcessDataAccess.GetAllHydratedProcesses();
            AllProcesses = theProcesses.ToList();

            foreach (var process in AllProcesses)
            {
                process.Revisions.OrderByDescending(i => i.ProcessRevId);
            }

            var theSteps = await StepDataAccess.GetAllSteps();
            AllSteps = theSteps.ToList();

            var theOperations = await OperationDataAccess.GetAllOperations();
            AllOperations = theOperations.OrderBy(i => i.Name).ToList();

            CurrentProcess = new ProcessModel(); //This needs to be created even if there isn't a process being passed in so the front-end doesn't throw a null reference exception when looking for a name.

            CurrentRev = new ProcessRevisionModel(); //This also needs to be created right away so the front-end does throw a null reference exception when loading the current step list.
            CurrentRev.StepSeqs = new List<StepSeqModel>();

            CurrentStepIds = null;
            CurrentOperationIds = null;

            if (aProcessId > 0)
            {
                CurrentProcess = AllProcesses.FirstOrDefault(i => i.ProcessId == aProcessId);
                CurrentProcessId = aProcessId;
                if (CurrentProcess.Revisions.Any())
                {
                    ModelState.Remove("CurrentRevId"); //The input field wasn't updating when deleting an unlocked revision.  This clears the model state for just this property
                    CurrentRev = CurrentProcess.Revisions.OrderByDescending(i => i.ProcessRevId).FirstOrDefault();
                    CurrentRevId = CurrentRev.ProcessRevId;
                    Comment = CurrentRev.Comments;
                    EmpCreatedCurrentRev = await EmployeeDataAccess.GetEmployeeById(CurrentRev.CreatedByEmp);
                    CurrentOperations = new List<OperationModel>();
                    //Finds each unique operation within the revision's steps and loads it into CurrentOperations.
                    foreach (var stepSeq in CurrentRev.StepSeqs)
                    {
                        var shouldThisStepBeAdded = true;
                        foreach (var operation in CurrentOperations)
                        {
                            if (operation.Id == stepSeq.Operation.Id)
                            {
                                shouldThisStepBeAdded = false;
                            }
                        }
                        if (shouldThisStepBeAdded) { CurrentOperations.Add(stepSeq.Operation); }
                    }

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