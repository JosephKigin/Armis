using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
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
        [TempData]
        public string StepJson { get; set; }
        public StepModel Step { get; set; }
        
        [TempData]
        public string VariableTemplateModelsJson { get; set; }
        public List<VariableTemplateModel> VariableTemplateModels { get; set; }
        
        [TempData]
        public string UomModelsJson { get; set; }
        public List<UOMCodeModel> UomModels { get; set; }
        public List<SelectListItem> UOMSelectItems { get; set; }

        //Bound Properties
        [BindProperty]
        public int Min1 { get; set; }

        [BindProperty]
        public int Max1 { get; set; }

        [BindProperty]
        public string UomCode1 { get; set; }

        [BindProperty]
        [Required]
        public string TemplateCode1 { get; set; }

        [BindProperty]
        public int Min2 { get; set; }

        [BindProperty]
        public int Max2 { get; set; }

        [BindProperty]
        public string UomCode2 { get; set; }

        [BindProperty]
        public string TemplateCode2 { get; set; }

        [BindProperty]
        public int Min3 { get; set; }

        [BindProperty]
        public int Max3 { get; set; }

        [BindProperty]
        public string UomCode3 { get; set; }

        [BindProperty]
        public string TemplateCode3 { get; set; }

        [BindProperty]
        public int Min4 { get; set; }

        [BindProperty]
        public int Max4 { get; set; }

        [BindProperty]
        public string UomCode4 { get; set; }

        [BindProperty]
        public string TemplateCode4 { get; set; }

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
            
            if (Step.Variables != null)
            {

            }

            await SetUpPage();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var theStepVariablesToAdd = new List<StepVariableModel>();
            var theStepToAdd = JsonSerializer.Deserialize<StepModel>(StepJson);
            var theUomModels = JsonSerializer.Deserialize<List<UOMCodeModel>>(UomModelsJson);
            var theVariableTemplateModels = JsonSerializer.Deserialize<List<VariableTemplateModel>>(VariableTemplateModelsJson);

            //Variable 1
            var theStepVarToAdd1 = new StepVariableModel { Min = Min1, Max = Max1 };
            theStepVarToAdd1.UnitOfMeasure = (UomCode1 != "none") ? theUomModels.FirstOrDefault(i => i.Code == UomCode1) : null; //The top option for Uom code select is "none", a.k.a. null
            theStepVarToAdd1.Template = theVariableTemplateModels.FirstOrDefault(i => i.Code == TemplateCode1);
            theStepVariablesToAdd.Add(theStepVarToAdd1);

            //Variable 2
            if (TemplateCode2 != null)
            {
                var theStepVarToAdd2 = new StepVariableModel { Min = Min2, Max = Max2 };
                theStepVarToAdd2.UnitOfMeasure = (UomCode2 != "none") ? theUomModels.FirstOrDefault(i => i.Code == UomCode2) : null;
                theStepVarToAdd2.Template = theVariableTemplateModels.FirstOrDefault(i => i.Code == TemplateCode2);
                theStepVariablesToAdd.Add(theStepVarToAdd2);
            }


            //Variable 3
            if (TemplateCode3 != null)
            {
                var theStepVarToAdd3 = new StepVariableModel { Min = Min3, Max = Max3 };
                theStepVarToAdd3.UnitOfMeasure = (UomCode3 != "none") ? theUomModels.FirstOrDefault(i => i.Code == UomCode3) : null;
                theStepVarToAdd3.Template = theVariableTemplateModels.FirstOrDefault(i => i.Code == TemplateCode3);
                theStepVariablesToAdd.Add(theStepVarToAdd3);
            }


            //Variable 4
            if (TemplateCode4 != null)
            {
                var theStepVarToAdd4 = new StepVariableModel { Min = Min4, Max = Max4 };
                theStepVarToAdd4.UnitOfMeasure = (UomCode4 != "none") ? theUomModels.FirstOrDefault(i => i.Code == UomCode4) : null;
                theStepVarToAdd4.Template = theVariableTemplateModels.FirstOrDefault(i => i.Code == TemplateCode4);
                theStepVariablesToAdd.Add(theStepVarToAdd4);
            }

            theStepToAdd.Variables = theStepVariablesToAdd;

            await StepDataAccess.AddVariablesToStep(theStepToAdd);

            return Page();
        }

        private async Task SetUpPage()
        {
            try
            {
                var theTempModels = await VariableDataAccess.GetAllTemplates();
                VariableTemplateModels = theTempModels.ToList();

                var resultUOMs = await UomDataAccess.GetAllUOMCodes();
                UomModels = resultUOMs.ToList();
                UOMSelectItems = new List<SelectListItem>();
                UOMSelectItems.Add(new SelectListItem { Text = "", Value = "none" });
                foreach (var uom in UomModels)
                {
                    UOMSelectItems.Add(new SelectListItem
                    {
                        Text = uom.Description,
                        Value = uom.Code
                    });
                }

                //Serializing data to be stored as Temp Data.
                StepJson = null;
                VariableTemplateModelsJson = null;
                UomModelsJson = null;
                StepJson = JsonSerializer.Serialize(Step);
                VariableTemplateModelsJson = JsonSerializer.Serialize(VariableTemplateModels);
                UomModelsJson = JsonSerializer.Serialize(UomModels);
                TempData.Keep("StepJson");
                TempData.Keep("VariableTemplateModelsJson");
                TempData.Keep("UomModelsJson");
            }
            catch (Exception ex)
            {

            }
        }
    }
}