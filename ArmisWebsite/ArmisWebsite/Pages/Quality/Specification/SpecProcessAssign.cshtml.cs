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
            //All of these calls will grab an IEnumerable of models from the api, assign that IEnumerable to a temp variable, and then assign that temp variable to a property while also changing it to a list.  If the IEnumerable/temp variable is null, then an empty list will be assigned to the property instead.
            var tempAllBakes = await StepDataAccess.GetAllStepsByCategory("bake");
            AllBakeSteps = (tempAllBakes != null)? tempAllBakes.ToList() : new List<StepModel>();

            var tempAllMasks = await StepDataAccess.GetAllStepsByCategory("mask");
            AllMaskSteps = (tempAllMasks != null)? tempAllMasks.ToList() : new List<StepModel>();

            var tempAllHardnesses = await HardnessDataAccess.GetAllHardnesses();
            AllHardnesses = (tempAllHardnesses != null)? tempAllHardnesses.ToList(): new List<HardnessModel>();

            var tempAllSeries = await MaterialSeriesDataAccess.GetAllMaterialSeries();
            AllMaterialSeries = (tempAllSeries != null)? tempAllSeries.ToList() : new List<MaterialSeriesModel>();

            var tempAllAlloys = await MaterialAlloyDataAccess.GetAllMaterialAlloys();
            AllMaterialAlloys = (tempAllAlloys != null)? tempAllAlloys.ToList() : new List<MaterialAlloyModel>();
        }
    }
}