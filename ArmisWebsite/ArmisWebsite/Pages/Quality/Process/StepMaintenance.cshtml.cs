using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.QualityModels.Process;
using ArmisWebsite.DataAccess.Quality;
using ArmisWebsite.DataAccess.Quality.Interfaces;
using ArmisWebsite.FrontEndModels;
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

        [BindProperty, MaxLength(50)]
        [Required]
        [Display(Name = "Name")]
        public string StepName { get; set; }

        [BindProperty]
        [Required]
        public bool IsSignOffRequired { get; set; } //0 is no selection, 1 is Yes, 2 is No.  No and no selection will both mean false.

        [BindProperty]
        [Required]
        [Display(Name = "Category")]
        public short StepCategoryId { get; set; }

        [BindProperty, MaxLength(500)]
        [Required]
        [Display(Name = "Instructions")]
        public string StepInstructions { get; set; }

        [BindProperty]
        public PopUpMessageModel Message { get; set; }

        public StepMaintenanceModel(IConfiguration aConfig,
                                    IStepDataAccess aStepDataAccess)
        {
            Config = aConfig;
            StepDataAccess = aStepDataAccess;
        }

        public async Task<IActionResult> OnGetAsync(int aStepId = 0, string aMessage = "", bool isMessageGood = false)
        {
            await SetUpPage();

            if (aMessage != "")
            {
                Message = new PopUpMessageModel()
                {
                    Text = aMessage,
                    IsMessageGood = isMessageGood
                };

            }
            if (aStepId > 0)
            {
                Step = await StepDataAccess.GetStepById(aStepId);

                StepCategoryId = Step.StepCategory.Id;
                StepName = Step.StepName;
                StepInstructions = Step.Instructions;

                HelpMessage = "This is a copy of a step.  You may edit the step details and save it back as a new step.";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await SetUpPage();
                return Page();
            }

            if (Step == null) { Step = new StepModel(); }
            Step.Instructions = StepInstructions;
            Step.SignOffIsRequired = IsSignOffRequired;
            Step.StepName = StepName;
            Step.StepCategory = await StepDataAccess.GetStepCategoryById(StepCategoryId);

            var currentStepsWithSameName = await StepDataAccess.GetStepByName(StepName);
            if (currentStepsWithSameName != null && currentStepsWithSameName.Any())
            {
                var stepExistsMessage = "A step with that name already exists.";
                return RedirectToPage("StepMaintenance", new { aStepId = currentStepsWithSameName[0].StepId, aMessage = stepExistsMessage });
            }

            var theStepId = await StepDataAccess.PostNewStep(Step);

            return RedirectToPage("StepMaintenance", new { aStepId = theStepId.StepId, aMessage = "Step saved successfully", isMessageGood = true });
        }

        private async Task SetUpPage()
        {
            var theSteps = await StepDataAccess.GetAllSteps();
            AllSteps = theSteps.OrderBy(i => i.StepId).ToList();

            var theStepCategories = await StepDataAccess.GetAllStepCategoryies();
            StepCategories = theStepCategories.ToList();
        }
    }
}