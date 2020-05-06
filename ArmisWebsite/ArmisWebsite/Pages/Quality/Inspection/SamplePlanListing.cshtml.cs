using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.QualityModels.Spec;
using ArmisWebsite.DataAccess.Quality.Inspection.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArmisWebsite.Pages.Quality.Inspection
{
    public class SamplePlanListingModel : PageModel
    {
        //DataAccess
        public ISamplePlanDataAccess SamplePlanDataAccess { get; set; }

        //Models
        public List<SamplePlanModel> AllSamplePlans { get; set; }

        //Front-End


        public SamplePlanListingModel(ISamplePlanDataAccess aSamplePlanDataAccess)
        {
            SamplePlanDataAccess = aSamplePlanDataAccess;
        }

        public async Task<ActionResult> OnGet()
        {
            await SetUpProperties();

            return Page();
        }

        public async Task SetUpProperties()
        {
            var tempSamplePlanModels = await SamplePlanDataAccess.GetAllHydratedSamplePlans();
            AllSamplePlans = tempSamplePlanModels.ToList();
        }
    }
}