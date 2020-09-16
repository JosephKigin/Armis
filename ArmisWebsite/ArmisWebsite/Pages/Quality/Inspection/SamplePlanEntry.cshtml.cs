using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.QualityModels.InspectionModels;
using Armis.BusinessModels.QualityModels.Spec;
using ArmisWebsite.DataAccess.Quality.Inspection.Interfaces;
using ArmisWebsite.FrontEndModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArmisWebsite.Pages.Quality.Inspection
{
    public class SamplePlanEntryModel : PageModel
    {
        /*
         * ~SUMMARY~
         * The only properties that use model binding are the name, description, and the amount of levels and tests.  All the other inputs are dynamic and would be really difficult to use model binding with (they would require lists in lists and/or tuples, which do not suit model binding well).  When the form is posted, it will look at the amount of levels and tests and pull the values using HttpContext.request.form.  It will then build the model with these values and send it off to the API.  Since Model binding isn't being used for most of the inputs, it doesn't make sense to have any validation on the server side.  All validation is done in javascript/jquery on the client side.
         */

        //Data Access
        public ITestTypeDataAccess TestTypeDataAccess { get; set; }
        public ISamplePlanDataAccess SamplePlanDataAccess { get; set; }


        //Models


        //Front-End
        //The rest of the values will be pulled using HttpContext.  This is usually not the best way to do it, but in this case the inputs are too variable to handle it with model binding.`
        [BindProperty]
        public List<SelectListItem> AllTestTypeSelectItems { get; set; }

        [BindProperty]
        public string SamplePlanName { get; set; }

        [BindProperty]
        public string SamplePlanDescription { get; set; }

        [BindProperty]
        public int AmountOfLevels { get; set; }

        [BindProperty]
        public int AmountOfTests { get; set; }

        [BindProperty]
        public PopUpMessageModel Message { get; set; }

        public SamplePlanEntryModel(ITestTypeDataAccess aTestTypeDataAccess, ISamplePlanDataAccess aSamplePlanDataAccess)
        {
            TestTypeDataAccess = aTestTypeDataAccess;
            SamplePlanDataAccess = aSamplePlanDataAccess;
        }

        public async Task<IActionResult> OnGet(string aMessage, bool? isMessageGood)
        {
            Message = new PopUpMessageModel()
            {
                Text = aMessage,
                IsMessageGood = isMessageGood
            };

            await SetUpProperties();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if(!(await SamplePlanDataAccess.CheckIfNameIsUnique(SamplePlanName))) 
            {
                Message = new PopUpMessageModel()
                {
                    IsMessageGood = false,
                    Text = "A sameple plan with that name already exists."
                };
                return Page(); 
            }

            var newSamplePlan = new SamplePlanModel()
            {
                PlanName = SamplePlanName,
                Description = SamplePlanDescription
            };
            var tempLevelModelList = new List<SamplePlanLevelModel>();

            for (int i = 1; i <= AmountOfLevels; i++)
            {
                var fromValue = int.Parse(HttpContext.Request.Form["inputNumOfPartsFrom" + i]);
                int toValue;
                if (i == AmountOfLevels) { toValue = int.MaxValue; }
                else { toValue = int.Parse(HttpContext.Request.Form["inputNumOfPartsTo" + i]); }
                var newSamplePlanLevel = new SamplePlanLevelModel()
                {
                    SamplePlanLevelId = i,
                    FromQty = fromValue,
                    ToQty = toValue
                };

                var tempRejectModelList = new List<SamplePlanRejectModel>();

                for (int j = 1; j <= AmountOfTests; j++)
                {
                    var sampleQty = int.Parse(HttpContext.Request.Form["inputSampleNum" + j + "-" + i]);
                    var rejectQty = int.Parse(HttpContext.Request.Form["inputRejectNum" + j + "-" + i]);
                    var testTypeId = short.Parse(HttpContext.Request.Form["selectTestType" + j]);

                    var newSamplePlanReject = new SamplePlanRejectModel()
                    {
                        SamplePlanLevelId = i,
                        SampleQty = sampleQty,
                        RejectAllowQty = rejectQty,
                        InspectTestTypeId = testTypeId
                    };

                    tempRejectModelList.Add(newSamplePlanReject);
                }

                newSamplePlanLevel.SamplePlanRejectModels = tempRejectModelList;

                tempLevelModelList.Add(newSamplePlanLevel);
            }

            newSamplePlan.SamplePlanLevelModels = tempLevelModelList;

            await SamplePlanDataAccess.CreateNewSamplePlan(newSamplePlan);

            return RedirectToPage("/Quality/Inspection/SamplePlanEntry", new { aMessage = "Sample Plan created successfully", isMessageGood = true });

        }

        public async Task SetUpProperties()
        {
            var allTestTypeModels = await TestTypeDataAccess.GetAllTestTypes();
            AllTestTypeSelectItems = new List<SelectListItem>();
            foreach (var testType in allTestTypeModels)
            {
                AllTestTypeSelectItems.Add(new SelectListItem
                {
                    Text = testType.Description,
                    Value = testType.InspectTestId.ToString()
                });
            }
        }
    }
}