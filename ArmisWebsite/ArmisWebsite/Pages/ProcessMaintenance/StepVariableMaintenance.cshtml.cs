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

        //Set up Data
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

        //Bound data
        [BindProperty]
        public int VariableCount { get; set; }


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
            try
            {
                //TODO delete the next line
                int failTest = int.Parse("Hello");

                var test = HttpContext.Request.Form["Uom 0"];

                var theStepVariablesToAdd = new List<StepVariableModel>();
                var theStepToAdd = JsonSerializer.Deserialize<StepModel>(StepJson);
                var theUomModels = JsonSerializer.Deserialize<List<UOMCodeModel>>(UomModelsJson);
                var theVariableTemplateModels = JsonSerializer.Deserialize<List<VariableTemplateModel>>(VariableTemplateModelsJson);

                var theAmountOfVariables = int.Parse(HttpContext.Request.Form["variableCardCount"]);

                //Reading all the values from the page and loading them into the class properties
                for (int i = 0; i < theAmountOfVariables; i++)
                {
                    var min = HttpContext.Request.Form["Min " + i];
                    var max = HttpContext.Request.Form["Max " + i];
                    var uom = HttpContext.Request.Form["Uom " + i];
                    var template = HttpContext.Request.Form["Template " + i];

                    var stepVariable = new StepVariableModel();

                    if (string.IsNullOrEmpty(min)) { stepVariable.Min = null; }
                    else { stepVariable.Min = decimal.Parse(min); }

                    if (string.IsNullOrEmpty(max)) { stepVariable.Max = null; }
                    else { stepVariable.Max = decimal.Parse(max); }

                    stepVariable.UnitOfMeasure = theUomModels.FirstOrDefault(i => i.Code == uom);
                    stepVariable.Template = theVariableTemplateModels.FirstOrDefault(i => i.Code == template);

                    theStepVariablesToAdd.Add(stepVariable);
                }

                theStepToAdd.Variables = theStepVariablesToAdd;

                await StepDataAccess.AddVariablesToStep(theStepToAdd);

                TempData.Clear();

                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error", new {exMessage = ex.Message });  //Todo: this will not work!!!  Need to implement logging and return a                                                                                                                     smaller value
            }

        }

        private async Task SetUpPage()
        {
            try
            {
                var theTempModels = await VariableDataAccess.GetAllTemplates();
                VariableTemplateModels = theTempModels.ToList();

                var resultUOMs = await UomDataAccess.GetAllUOMCodes();
                UomModels = resultUOMs.ToList();
                //UOMSelectItems = new List<SelectListItem>();
                //UOMSelectItems.Add(new SelectListItem { Text = "", Value = "none" });
                //foreach (var uom in UomModels)
                //{
                //    UOMSelectItems.Add(new SelectListItem
                //    {
                //        Text = uom.Description,
                //        Value = uom.Code
                //    });
                //}

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