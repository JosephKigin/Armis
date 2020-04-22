using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.Customer;
using Armis.BusinessModels.PartModels;
using Armis.BusinessModels.QualityModels.Process;
using ArmisWebsite.DataAccess.Customer.Interfaces;
using ArmisWebsite.DataAccess.Part.Interfaces;
using ArmisWebsite.DataAccess.Quality.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArmisWebsite.Pages.ProcessMaintenance
{
    public class SpecProcessAssignModel : PageModel
    {
        //Data Access
        public IStepDataAccess StepDataAccess { get; set; }
        public ICustomerDataAccess CustomerDataAccess { get; set; }
        public IHardnessDataAccess HardnessDataAccess { get; set; }
        public IMaterialSeriesDataAccess MaterialSeriesDataAccess { get; set; }
        public IMaterialAlloyDataAccess MaterialAlloyDataAccess { get; set; }

        //Models
        public List<StepModel> AllBakeSteps { get; set; } //This will be for both Pre-Bake and Post-Bake
        public List<StepModel> AllMaskSteps { get; set; }
        public List<HardnessModel> AllHardnesses { get; set; }
        public List<MaterialSeriesModel> AllMaterialSeries { get; set; }
        public List<MaterialAlloyModel> AllMaterialAlloys { get; set; }
        public List<CustomerModel> AllCustomers { get; set; }

        //Front-End
        [BindProperty]
        public int SpecRev { get; set; }

        public SpecProcessAssignModel(IStepDataAccess aStepDataAccess,
                                      ICustomerDataAccess aCustomerDataAccess,
                                      IHardnessDataAccess aHardnessDataAccess,
                                      IMaterialSeriesDataAccess aMaterialSeriesDataAccess,
                                      IMaterialAlloyDataAccess aMaterialAlloyDataAccess)
        {
            StepDataAccess = aStepDataAccess;
            CustomerDataAccess = aCustomerDataAccess;
            HardnessDataAccess = aHardnessDataAccess;
            MaterialSeriesDataAccess = aMaterialSeriesDataAccess;
            MaterialAlloyDataAccess = aMaterialAlloyDataAccess;
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
            var tempAllBakes = await StepDataAccess.GetAllStepsByCategory("bake");
            AllBakeSteps = tempAllBakes.ToList();

            var tempAllMasks = await StepDataAccess.GetAllStepsByCategory("mask");
            AllMaskSteps = tempAllMasks.ToList();

            var tempAllHardnesses = await HardnessDataAccess.GetAllHardnesses();
            AllHardnesses = (tempAllHardnesses != null)? tempAllHardnesses.ToList(): null;

            var tempAllSeries = await MaterialSeriesDataAccess.GetAllMaterialSeries();
            AllMaterialSeries = tempAllSeries.ToList();

            var tempAllAlloys = await MaterialAlloyDataAccess.GetAllMaterialAlloys();
            AllMaterialAlloys = tempAllAlloys.ToList();
        }
    }
}