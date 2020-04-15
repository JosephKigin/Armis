using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public List<StepModel> AllSteps { get; set; }
        public StepModel Step { get; set; }
        public List<StepCategoryModel> StepCategories { get; set; }

        //Web properties
        public string HelpMessage { get; set; }

        [BindProperty]
        [Required]
        public string StepName { get; set; }

        [BindProperty]
        [Required]
        public int IsSignOffRequired { get; set; } //0 is no selection, 1 is Yes, 2 is No.  No and no selection will both mean false.

        [BindProperty]
        [Required]
        public string StepCategoryCode { get; set; }

        [BindProperty]
        [Required]
        public string StepInstructions { get; set; }

        [BindProperty]
        public string Message { get; set; }

        public bool IsMessageGood { get; set; }

        public StepMaintenanceModel(IConfiguration aConfig,
                                    IStepDataAccess aStepDataAccess)
        {
            Config = aConfig;
            StepDataAccess = aStepDataAccess;
        }

        public async Task<IActionResult> OnGetAsync(int aStepId = 0, string aMessage = "", bool isMessageGood = false)
        {
            try
            {
                await SetUpPage();

                if (aMessage != "") 
                { 
                    Message = aMessage;
                    IsMessageGood = isMessageGood;
                }
                if (aStepId > 0)
                {
                    Step = await StepDataAccess.GetStepById(aStepId);

                    StepCategoryCode = Step.StepCategory.Code;
                    StepName = Step.StepName;
                    StepInstructions = Step.Instructions;

                    HelpMessage = "This is a copy of a step.  You may edit the step details and save it back as a new step.";
                }

                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error", new { exMessage = "Could not set up page properly. " + ex.Message });  //Todo: this will not work!!!  Need to implement logging and return a                                                                                                                     smaller value
            }

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await SetUpPage();
                return Page();
            }

            try
            {
                if (Step == null) { Step = new StepModel(); }
                Step.Instructions = StepInstructions;
                Step.SignOffIsRequired = (IsSignOffRequired == 1) ? true : false;
                Step.StepName = StepName;
                Step.StepCategory = await StepDataAccess.GetStepCategoryByCode(StepCategoryCode);

                var currentStepsWithSameName = await StepDataAccess.GetStepByName(StepName);
                if (currentStepsWithSameName != null && currentStepsWithSameName.Any())
                {
                    var stepExistsMessage = "A step with that name already exists.";
                    return RedirectToPage("StepMaintenance", new { aStepId = currentStepsWithSameName[0].StepId, aMessage = stepExistsMessage });
                }

                var theStepId = await StepDataAccess.PostNewStep(Step);

                return RedirectToPage("StepMaintenance", new {aMessage = "Step saved successfully", isMessageGood = true });
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error", new { exMessage = ex.Message });  ////Todo: this will not work!!!  Need to implement logging and return a                                                                                                                     smaller value
            }

        }

        private async Task SetUpPage()
        {
            var theSteps = await StepDataAccess.GetAllSteps();
            AllSteps = theSteps.OrderBy(i => i.StepName).ToList();

            var theStepCategories = await StepDataAccess.GetAllStepCategoryies();
            StepCategories = theStepCategories.ToList();
        }
    }
}