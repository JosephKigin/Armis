using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.Customer;
using Armis.BusinessModels.PartModels;
using Armis.BusinessModels.QualityModels.Process;
using Armis.BusinessModels.QualityModels.Spec;
using ArmisWebsite.DataAccess.Customer.Interfaces;
using ArmisWebsite.DataAccess.Part.Interfaces;
using ArmisWebsite.DataAccess.Quality.Interfaces;
using ArmisWebsite.DataAccess.Quality.Specification.Interfaces;
using ArmisWebsite.FrontEndModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ArmisWebsite.Pages.ProcessMaintenance
{
    public class SpecProcessAssignmentModel : PageModel
    {
        public readonly string _apiAddress;
        public readonly IConfiguration Config;
        //Data Access
        public ISpecProcessAssignDataAccess SpecProcessAssignDataAccess { get; set; }
        public IProcessDataAccess ProcessDataAccess { get; set; }
        public IStepDataAccess StepDataAccess { get; set; }
        public ICustomerDataAccess CustomerDataAccess { get; set; }
        public IHardnessDataAccess HardnessDataAccess { get; set; }
        public IMaterialSeriesDataAccess MaterialSeriesDataAccess { get; set; }
        public IMaterialAlloyDataAccess MaterialAlloyDataAccess { get; set; }
        public ISpecDataAccess SpecificationDataAccess { get; set; }

        //Models
        //Middle section of page
        public List<ProcessModel> AllProcessesWithCurrentRev { get; set; }

        //Right section of page
        public List<StepModel> AllBakeSteps { get; set; } //This will be for both Pre-Bake and Post-Bake
        public List<StepModel> AllMaskSteps { get; set; }
        public List<HardnessModel> AllHardnesses { get; set; }
        public List<MaterialSeriesModel> AllMaterialSeries { get; set; }
        public List<MaterialAlloyModel> AllMaterialAlloys { get; set; }
        public List<CustomerModel> AllCustomers { get; set; }
        public List<SpecModel> AllSpecifications { get; set; }
        public List<SpecProcessAssignModel> SpecProcessAssignsForCurrentSpec { get; set; }

        public SpecModel CurrentSpec { get; set; } //After a spec is selected by the used, the page will reload and this will be set to the selected spec and the page will be created based on it.
        public SpecRevModel CurrentSpecCurrentRev { get; set; }

        //Front-End
        public PopUpMessageModel Message { get; set; }
        //Left-Side
        [BindProperty]
        public int SpecId { get; set; } //Hidden input
        [BindProperty]
        public short SpecInternalRevId { get; set; } //Hidden input
        [BindProperty]
        public byte? ChoiceId1 { get; set; } //Hidden input
        [BindProperty]
        public byte? ChoiceId2 { get; set; } //Hidden input
        [BindProperty]
        public byte? ChoiceId3 { get; set; } //Hidden input
        [BindProperty]
        public byte? ChoiceId4 { get; set; } //Hidden input
        [BindProperty]
        public byte? ChoiceId5 { get; set; } //Hidden input
        [BindProperty]
        public byte? ChoiceId6 { get; set; } //Hidden input

        //Middle, Required
        [BindProperty]
        public int ProcessId { get; set; }
        [BindProperty]
        public int ProcessRevId { get; set; }  //Hidden input

        //Right Side, None of these are required
        [BindProperty]
        public int? PreBakeStepId { get; set; }
        [BindProperty]
        public int? PostBakeStepId { get; set; }
        [BindProperty]
        public int? MaskStepId { get; set; }
        [BindProperty]
        public int? HardnessId { get; set; }
        [BindProperty]
        public int? MaterialSeriesId { get; set; }
        [BindProperty]
        public int? MaterialAlloyId { get; set; }
        [BindProperty]
        public int? CustomerId { get; set; }


        public SpecProcessAssignmentModel(ISpecProcessAssignDataAccess aSpecProcessAssignDataAccess,
                                      IProcessDataAccess aProcessDataAccess,
                                      ISpecDataAccess aSpecDataAccess,
                                      IStepDataAccess aStepDataAccess,
                                      ICustomerDataAccess aCustomerDataAccess,
                                      IHardnessDataAccess aHardnessDataAccess,
                                      IMaterialSeriesDataAccess aMaterialSeriesDataAccess,
                                      IMaterialAlloyDataAccess aMaterialAlloyDataAccess,
                                      IConfiguration aConfig)
        {
            SpecProcessAssignDataAccess = aSpecProcessAssignDataAccess;
            ProcessDataAccess = aProcessDataAccess;
            SpecificationDataAccess = aSpecDataAccess;
            StepDataAccess = aStepDataAccess;
            CustomerDataAccess = aCustomerDataAccess;
            HardnessDataAccess = aHardnessDataAccess;
            MaterialSeriesDataAccess = aMaterialSeriesDataAccess;
            MaterialAlloyDataAccess = aMaterialAlloyDataAccess;
            Config = aConfig;
            _apiAddress = aConfig["APIAddress"];
        }

        public async Task<ActionResult> OnGet(int? aSpecId, string aMessage, bool? isMessageGood)
        {
            try
            {
                Message = new PopUpMessageModel()
                {
                    Text = aMessage,
                    IsMessageGood = isMessageGood
                };

                if (aSpecId != null)
                {
                    int tempSpecId = aSpecId ?? default(int); //Converts the int? to an int.  The part after ?? means that if aSpecId == null, then assign a 0 to tempSpecId, but the if() handles null.
                    CurrentSpec = await SpecificationDataAccess.GetHydratedCurrentRevOfSpec(tempSpecId);
                    CurrentSpecCurrentRev = CurrentSpec.SpecRevModels.OrderByDescending(i => i.InternalRev).FirstOrDefault();
                    SpecId = CurrentSpec.Id;
                    SpecInternalRevId = CurrentSpecCurrentRev.InternalRev;
                }
                await SetUpProperties();
                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error", new { ExMessage = ex.Message });
            }

        }

        public async Task<ActionResult> OnPost()
        {
            try
            {
                var theSpecProcessAssignModel = new Armis.BusinessModels.QualityModels.Spec.SpecProcessAssignModel()
                {
                    SpecId = SpecId,
                    SpecRevId = SpecInternalRevId,
                    ChoiceOptionId1 = ChoiceId1,
                    ChoiceOptionId2 = ChoiceId2,
                    ChoiceOptionId3 = ChoiceId3,
                    ChoiceOptionId4 = ChoiceId4,
                    ChoiceOptionId5 = ChoiceId5,
                    ChoiceOptionId6 = ChoiceId6,
                    PreBakeOptionId = PreBakeStepId,
                    PostBakeOptionId = PostBakeStepId,
                    MaskOptionId = MaskStepId,
                    HardnessOptionId = HardnessId,
                    SeriesOptionId = MaterialSeriesId,
                    AlloyOptionId = MaterialAlloyId,
                    CustomerId = CustomerId,
                    ProcessId = ProcessId,
                    ProcessRevId = ProcessRevId
                };

                var areChoicesUnique = await SpecProcessAssignDataAccess.VerifyUniqueChoices(SpecId, SpecInternalRevId, ChoiceId1 ?? 0, ChoiceId2 ?? 0, ChoiceId3 ?? 0, ChoiceId4 ?? 0, ChoiceId5 ?? 0, ChoiceId6 ?? 0, PreBakeStepId ?? 0, PostBakeStepId ?? 0, MaskStepId ?? 0, HardnessId ?? 0, MaterialSeriesId ?? 0, MaterialAlloyId ?? 0, CustomerId ?? 0);

                if (ModelState.IsValid && areChoicesUnique)
                {
                    await SpecProcessAssignDataAccess.PostSpecProcessAssign(theSpecProcessAssignModel);

                    return RedirectToPage("/Quality/Specification/SpecProcessAssign", new { aMessage = "Specification-Process assignment saved successfully", isMessageGood = true });
                }
                else
                {
                    if (!ModelState.IsValid)
                    {
                        await SetUpProperties();
                        return Page();
                    }
                    else if (!areChoicesUnique)
                    {
                        return RedirectToPage("/Quality/Specification/SpecProcessAssign", new { aMessage = "Another Specificaiton-Process assignment has already been created with those options", isMessageGood = false });
                    }

                    return RedirectToPage("/Error", new { ExMessage = "An unknown error occured" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error", new { ExMessage = ex.Message });
            }
        }

        public async Task SetUpProperties()
        {
            var tempAllBakes = await StepDataAccess.GetAllStepsByCategory("bake");
            AllBakeSteps = (tempAllBakes != null) ? tempAllBakes.ToList() : new List<StepModel>();

            var tempAllMasks = await StepDataAccess.GetAllStepsByCategory("mask");
            AllMaskSteps = (tempAllMasks != null) ? tempAllMasks.ToList() : new List<StepModel>();

            var tempAllHardnesses = await HardnessDataAccess.GetAllHardnesses();
            AllHardnesses = (tempAllHardnesses != null) ? tempAllHardnesses.ToList() : new List<HardnessModel>();

            var tempAllSeries = await MaterialSeriesDataAccess.GetAllMaterialSeries();
            AllMaterialSeries = (tempAllSeries != null) ? tempAllSeries.ToList() : new List<MaterialSeriesModel>();

            var tempAllAlloys = await MaterialAlloyDataAccess.GetAllMaterialAlloys();
            AllMaterialAlloys = (tempAllAlloys != null) ? tempAllAlloys.ToList() : new List<MaterialAlloyModel>();

            var tempAllCustomers = await CustomerDataAccess.GetAllCurrentAndProspectCustomers();
            AllCustomers = (tempAllCustomers != null) ? tempAllCustomers.ToList() : new List<CustomerModel>();

            var tempAllProcesses = await ProcessDataAccess.GetHydratedProcessesWithCurrentLockedRev();
            AllProcessesWithCurrentRev = (tempAllProcesses != null) ? tempAllProcesses.ToList() : new List<ProcessModel>();

            var tempAllSpecifications = await SpecificationDataAccess.GetAllHydratedSpecs();
            AllSpecifications = (tempAllSpecifications != null) ? tempAllSpecifications.ToList() : new List<SpecModel>();

            if (CurrentSpec != null)
            {
                var spaForSpecResult = await SpecProcessAssignDataAccess.GetAllActiveHydratedSpecProcessAssignForSpec(CurrentSpec.Id);
                if (spaForSpecResult != null && spaForSpecResult.Any()) 
                { SpecProcessAssignsForCurrentSpec = spaForSpecResult.ToList(); }
            }
        }
    }
}