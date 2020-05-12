using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.QualityModels.Spec;
using ArmisWebsite.DataAccess.Quality.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ArmisWebsite.Pages.ProcessMaintenance
{
    public class SpecificationListingModel : PageModel
    {
        public readonly string _apiAddress; //This is needed whenever javascrit is responsible for loading data from the API.

        //Data Access
        public ISpecDataAccess SpecDataAccess { get; set; }

        //Data Models
        public List<SpecModel> AllSpecs { get; set; }


        //Front-End Models

        public SpecificationListingModel(ISpecDataAccess aSpecDataAccess, IConfiguration aConfig)
        {
            SpecDataAccess = aSpecDataAccess;
            _apiAddress = aConfig["APIAddress"];
        }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                await SetUpProperties();

                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error", new { ExMessage = ex.Message });
            }
            ;
        }

        public async Task SetUpProperties()
        {
            var theAllSpecs = await SpecDataAccess.GetAllHydratedSpecsWithSamplePlans();
            AllSpecs = theAllSpecs.OrderBy(i => i.Code).ToList();
        }
    }
}