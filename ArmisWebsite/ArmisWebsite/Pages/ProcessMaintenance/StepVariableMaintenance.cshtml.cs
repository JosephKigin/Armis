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

namespace ArmisWebsite
{
    public class StepVariableMaintenanceModel : PageModel
    {
        //Data Access
        private IStepDataAccess StepDataAccess { get; set; }
        private IUomCodeDataAccess UomDataAccess { get; set; }
        private IVariableDataAccess VariableDataAccess { get; set; }
        
        //Data
        public StepModel Step { get; set; }
        public List<VariableTemplateModel> VariableTemplateModels { get; set; }
        public List<SelectListItem> UOMSelectItems { get; set; }

        //Bound Properties
        [BindProperty]
        public int Min1 { get; set; }
        
        [BindProperty]
        public int Max1 { get; set; }
        
        [BindProperty]
        public string Uom1 { get; set; }
        
        [BindProperty]
        public string Template1 { get; set; }
        
        [BindProperty]
        public int Min2 { get; set; }
        
        [BindProperty]
        public int Max2 { get; set; }
        
        [BindProperty]
        public string Uom2 { get; set; }
        
        [BindProperty]
        public string Template2 { get; set; }
        
        [BindProperty]
        public int Min3 { get; set; }

        [BindProperty]
        public int Max3 { get; set; }

        [BindProperty]
        public string Uom3 { get; set; }

        [BindProperty]
        public string Template3 { get; set; }

        [BindProperty]
        public int Min4 { get; set; }

        [BindProperty]
        public int Max4 { get; set; }
        
        [BindProperty]
        public string Uom4 { get; set; }

        [BindProperty]
        public string Template4 { get; set; }

        public StepVariableMaintenanceModel(IStepDataAccess aStepDataAccess,
                                            IUomCodeDataAccess aUomDataAccess,
                                            IVariableDataAccess aVariableDataAccess)
        {
            StepDataAccess = aStepDataAccess;
            UomDataAccess = aUomDataAccess;
            VariableDataAccess = aVariableDataAccess;
        }

        public async Task<IActionResult> OnGet(int aStepId)
        {
            Step = await StepDataAccess.GetStepById(aStepId);

            if(Step.Variables != null)
            {

            }

            await SetUpPage();

            return Page();
        }

        private async Task SetUpPage()
        {
            try
            {
                var theTempModels = await VariableDataAccess.GetAllTemplates();
                VariableTemplateModels = theTempModels.ToList();

                var resultUOMs = await UomDataAccess.GetAllUOMCodes();
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
            }
            catch (Exception ex)
            {

            }
        }
    }
}