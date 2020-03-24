using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.ProcessModels.Spec;
using ArmisWebsite.DataAccess.Process.Interfaces;
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
            await SetUpProperties();

            var TEST = AppSettings.Current.AppConnection;

            return Page();
        }

        public async Task SetUpProperties()
        {
            var theAllSpecs = await SpecDataAccess.GetAllHydratedSpecs();
            AllSpecs = theAllSpecs.ToList();
        }
    }
}