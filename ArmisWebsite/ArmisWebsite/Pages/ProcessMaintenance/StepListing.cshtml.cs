using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.ProcessModels;
using ArmisWebsite.DataAccess.Process;
using ArmisWebsite.DataAccess.Process.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ArmisWebsite
{
    public class StepListingModel : PageModel
    {
        private readonly IConfiguration Config;

        public IStepDataAccess StepDataAccess { get; set; }
        public List<StepModel> Steps { get; set; }

        public StepListingModel(IConfiguration aConfig, IStepDataAccess aStepDataAccess)
        {
            Config = aConfig;
            StepDataAccess = aStepDataAccess;
        }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                var theSteps = await StepDataAccess.GetAllSteps();
                Steps = theSteps.OrderBy(i => i.StepName).ToList();
                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error", new { ExMessage = ex.Message });
            }

        }
    }
}