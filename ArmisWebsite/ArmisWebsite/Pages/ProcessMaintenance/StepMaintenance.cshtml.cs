using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.ProcessModels;
using ArmisWebsite.DataAccess.Process;
using ArmisWebsite.DataAccess.Process.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace ArmisWebsite
{
    public class StepMaintenanceModel : PageModel
    {
        private readonly IConfiguration Config;

        //Data Access
        private readonly IStepDataAccess StepDataAccess;

        //Business Model Properties
        public List<VariableTemplateModel> AssignedVariableTemplateModels { get; set; }

        public List<StepModel> AllSteps { get; set; }

        public StepModel Step { get; set; }

        //Web properties
        [BindProperty]
        public string StepName { get; set; }

        [BindProperty]
        public bool IsSignOffRequired { get; set; }

        [BindProperty]
        public string StepCategory { get; set; }

        [BindProperty]
        public string StepInstructions { get; set; }

        [BindProperty]
        public List<SelectListItem> SignOffReqSelectList { get; set; }

        [BindProperty(SupportsGet = true)]
        public string StepSearch { get; set; }

        [BindProperty]
        public string Message { get; set; }

        public StepMaintenanceModel(IConfiguration aConfig,
                                    IStepDataAccess aStepDataAccess,
                                    IUomCodeDataAccess aUOMDataAccess)
        {
            Config = aConfig;
            StepDataAccess = aStepDataAccess;
        }

        public async Task<IActionResult> OnGetAsync(int aStepId = 0 , string aMessage = "")
        {
            try
            {
                await SetUpPage();
                if(aMessage != "") { Message = aMessage; }
                if (aStepId > 0)
                {
                    Step = await StepDataAccess.GetStepById(aStepId);

                    StepCategory = Step.StepCategoryCd;
                    StepName = Step.StepName;
                    StepInstructions = Step.Instructions;
                    IsSignOffRequired = (Step.SignOffIsRequired == true) ? true : false;

                    if (Step.SignOffIsRequired == true)
                    { SignOffReqSelectList.FirstOrDefault(i => i.Text == "Yes").Selected = true; }
                    else
                    { SignOffReqSelectList.FirstOrDefault(i => i.Text == "No").Selected = true; }
                }

                if(!string.IsNullOrEmpty(StepSearch))
                {
                    var tempSteps = new List<StepModel>();
                    tempSteps.AddRange(AllSteps);

                    foreach (var step in tempSteps)
                    {
                        if(!step.StepName.ToLower().Contains(StepSearch.ToLower()))
                        {
                            AllSteps.Remove(step);
                        }
                    }
                }

                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error", new { exMessage = "Could not set up page properly." });  //Todo: this will not work!!!  Need to implement logging and return a                                                                                                                     smaller value
            }

        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (Step == null) { Step = new StepModel(); }
                Step.Instructions = StepInstructions;
                Step.SignOffIsRequired = IsSignOffRequired;
                Step.StepName = StepName;
                Step.StepCategoryCd = "NONE";

                var currentStepsWithSameName = await StepDataAccess.GetStepByName(StepName);
                if (currentStepsWithSameName != null && currentStepsWithSameName.Any())
                {
                    var stepExistsMessage = "A step with that name already exists.";
                    return RedirectToPage("StepMaintenance", new { aMessage = stepExistsMessage });
                }

                var theStepId = await StepDataAccess.PostNewStep(Step);

                return RedirectToPage("StepMaintenance", new { aStepId = theStepId});
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error", new { exMessage = ex.Message });  ////Todo: this will not work!!!  Need to implement logging and return a                                                                                                                     smaller value
            }

        }

        private async Task SetUpPage()
        {
            try
            {
                var theSteps = await StepDataAccess.GetAllHydratedSteps();
                AllSteps = theSteps.ToList();

                SignOffReqSelectList = new List<SelectListItem>();
                SignOffReqSelectList.Add(new SelectListItem { Text = "", Value = "0" });
                SignOffReqSelectList.Add(new SelectListItem { Text = "Yes", Value = "1" });
                SignOffReqSelectList.Add(new SelectListItem { Text = "No", Value = "2", Selected = true });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}