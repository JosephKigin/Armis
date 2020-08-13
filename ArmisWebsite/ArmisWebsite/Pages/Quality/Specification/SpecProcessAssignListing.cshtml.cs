using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.QualityModels.Spec;
using ArmisWebsite.DataAccess.Quality.Specification.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArmisWebsite.Pages.Quality.Specification
{
    public class SpecProcessAssignListingModel : PageModel
    {
        //Data Access
        public ISpecProcessAssignDataAccess SpecProcessAssignDataAccess { get; set; }

        //Model Properties
        public IEnumerable<SpecProcessAssignModel> AllSpecProcessAssigns { get; set; }

        public SpecProcessAssignListingModel(ISpecProcessAssignDataAccess aSpecProcessAssignDataAccess)
        {
            SpecProcessAssignDataAccess = aSpecProcessAssignDataAccess;
        }

        public async Task<ActionResult> OnGet()
        {
            await SetUpProperties();

            return Page();
        }

        public async Task SetUpProperties()
        {
            var tempSpecProcessAssign = await SpecProcessAssignDataAccess.GetAllActiveHydratedSpecProcessAssigns();
            AllSpecProcessAssigns = tempSpecProcessAssign.ToList();
        }

    }
}