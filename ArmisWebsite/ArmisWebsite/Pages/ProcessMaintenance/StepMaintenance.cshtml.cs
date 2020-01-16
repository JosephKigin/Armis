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
        private readonly IVariableDataAccess VariableDataAccess;

        private readonly IStepDataAccess StepDataAccess;

        private readonly IUomCodeDataAccess UOMDataAccess;

        //Business Model Properties
        public List<VariableTemplateModel> VariableTemplateModels { get; set; }
        public List<VariableTemplateModel> AssignedVariableTemplateModels { get; set; }

        public List<SelectListItem> UOMSelectItems { get; set; }

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
        public string VariableTemplateToAdd { get; set; }

        [BindProperty]
        public List<SelectListItem> SignOffReqSelectList { get; set; }

        public StepMaintenanceModel(IConfiguration aConfig, 
                                    IStepDataAccess aStepDataAccess, 
                                    IUomCodeDataAccess aUOMDataAccess, 
                                    IVariableDataAccess aVariableDataAccess)
        {
            Config = aConfig;
            StepDataAccess = aStepDataAccess;
            UOMDataAccess = aUOMDataAccess;
            VariableDataAccess = aVariableDataAccess;
        }

        public async Task<IActionResult> OnGetAsync(int aStepId = 0)
        {
            await SetUpPage();
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

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(Step == null) { Step = new StepModel(); }
            Step.Instructions = StepInstructions;
            Step.SignOffIsRequired = IsSignOffRequired;
            Step.StepName = StepName;
            Step.StepCategoryCd = "NONE";

            //var theStepId = await StepDataAccess.PostNewStep(Step);

            return RedirectToPage("StepVariableMaintenance", new {aStepId = 3 }); //TODO::Change this back to theStepId
        }

        private async Task SetUpPage()
        {
            try
            {
                var theTempModels = await VariableDataAccess.GetAllTemplates();
                VariableTemplateModels = theTempModels.ToList();

                var resultUOMs = await UOMDataAccess.GetAllUOMCodes();
                var theUOMsList = resultUOMs.ToList();
                UOMSelectItems = new List<SelectListItem>();
                foreach (var uom in theUOMsList)
                {
                    UOMSelectItems.Add(new SelectListItem
                    {
                        Text = uom.Description,
                        Value = uom.Code
                    });
                }

                SignOffReqSelectList = new List<SelectListItem>();
                SignOffReqSelectList.Add(new SelectListItem { Text = "", Value = "0" });
                SignOffReqSelectList.Add(new SelectListItem { Text = "Yes", Value = "1" });
                SignOffReqSelectList.Add(new SelectListItem { Text = "No", Value = "2", Selected = true });
            }
            catch (Exception ex)
            {

            }
        }
    }
}