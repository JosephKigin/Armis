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
    public class SpecProcessAssignReviewModel : PageModel
    {
        //Data Access
        public ISpecProcessAssignDataAccess SpecProcessAssignDataAccess { get; set; }

        //Model Properties
        public IEnumerable<SpecProcessAssignModel> AllSpecProcessAssigns { get; set; }

        public SpecProcessAssignReviewModel(ISpecProcessAssignDataAccess aSpecProcessAssignDataAccess)
        {
            SpecProcessAssignDataAccess = aSpecProcessAssignDataAccess;
        }

        public async Task<ActionResult> OnGet()
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

        }

        public async Task SetUpProperties()
        {
            var tempSpecProcessAssign = await SpecProcessAssignDataAccess.GetAllReviewNeededSpecProcessAssign();
            AllSpecProcessAssigns = tempSpecProcessAssign.ToList();
        }
    }
}