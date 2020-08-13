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
using Microsoft.CodeAnalysis.Options;
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
        public ICustomerDataAccess CustomerDataAccess { get; set; }
        public ISpecDataAccess SpecificationDataAccess { get; set; }

        //Models
        public List<ProcessModel> AllProcessesWithCurrentRev { get; set; }
        public List<CustomerModel> AllCustomers { get; set; }
        public List<SpecModel> AllSpecifications { get; set; }

        public List<SpecProcessAssignModel> SpecProcessAssignsForCurrentSpec { get; set; }

        public SpecModel CurrentSpec { get; set; } //After a spec is selected by the used, the page will reload and this will be set to the selected spec and the page will be created based on it.
        public SpecRevModel CurrentSpecCurrentRev { get; set; }
        public bool IsReviewNeededForCurrentSpec { get; set; }

        public List<SpecProcessAssignmentModel> HistorySpecProcAssigns { get; set; }

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
            CustomerDataAccess = aCustomerDataAccess;
            Config = aConfig;
            _apiAddress = aConfig["APIAddress"];
        }

        public async Task<ActionResult> OnGet(int? aSpecId, string aMessage, bool? isMessageGood)
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

                //ToDo: Get history SPAs for the spec selected.  Populate a history modal or collapsable or something like that
            }
            await SetUpProperties();
            return Page();
        }

        public async Task<ActionResult> OnPost()
        {
            var optionModels = new List<SpecProcessAssignOptionModel>();

            if (ChoiceId1 != null)
            {
                optionModels.Add(new SpecProcessAssignOptionModel()
                {
                    SpecId = SpecId,
                    SpecRevId = SpecInternalRevId,
                    SubLevelSeqId = 1, //TODO: Should this be hard-coded to 1?
                    ChoiceSeqId = (byte)ChoiceId1
                });
            }

            if (ChoiceId2 != null)
            {
                optionModels.Add(new SpecProcessAssignOptionModel()
                {
                    SpecId = SpecId,
                    SpecRevId = SpecInternalRevId,
                    SubLevelSeqId = 2, //TODO: Should this be hard-coded to 2?
                    ChoiceSeqId = (byte)ChoiceId2
                });
            }

            if (ChoiceId3 != null)
            {
                optionModels.Add(new SpecProcessAssignOptionModel()
                {
                    SpecId = SpecId,
                    SpecRevId = SpecInternalRevId,
                    SubLevelSeqId = 3, //TODO: Should this be hard-coded to 3?
                    ChoiceSeqId = (byte)ChoiceId3
                });
            }

            if (ChoiceId4 != null)
            {
                optionModels.Add(new SpecProcessAssignOptionModel()
                {
                    SpecId = SpecId,
                    SpecRevId = SpecInternalRevId,
                    SubLevelSeqId = 4, //TODO: Should this be hard-coded to 4?
                    ChoiceSeqId = (byte)ChoiceId4
                });
            }

            if (ChoiceId5 != null)
            {
                optionModels.Add(new SpecProcessAssignOptionModel()
                {
                    SpecId = SpecId,
                    SpecRevId = SpecInternalRevId,
                    SubLevelSeqId = 5, //TODO: Should this be hard-coded to 5?
                    ChoiceSeqId = (byte)ChoiceId5
                });
            }

            if (ChoiceId6 != null)
            {
                optionModels.Add(new SpecProcessAssignOptionModel()
                {
                    SpecId = SpecId,
                    SpecRevId = SpecInternalRevId,
                    SubLevelSeqId = 6, //TODO: Should this be hard-coded to 6?
                    ChoiceSeqId = (byte)ChoiceId6
                });
            }

            var theSpecProcessAssignModel = new Armis.BusinessModels.QualityModels.Spec.SpecProcessAssignModel()
            {
                SpecId = SpecId,
                SpecRevId = SpecInternalRevId,
                CustomerId = CustomerId,
                ProcessId = ProcessId,
                ProcessRevId = ProcessRevId,
                SpecProcessAssignOptionModels = optionModels
            };

            var areChoicesUnique = await SpecProcessAssignDataAccess.VerifyUniqueChoices(SpecId, SpecInternalRevId, CustomerId ?? 0, optionModels);

            if (ModelState.IsValid && areChoicesUnique)
            {
                await SpecProcessAssignDataAccess.PostSpecProcessAssign(theSpecProcessAssignModel);

                return RedirectToPage("/Quality/Specification/SpecProcessAssign", new { aMessage = "Specification-Process assignment saved successfully", isMessageGood = true });
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    Message = new PopUpMessageModel()
                    {
                        Text = "Process is required",
                        IsMessageGood = false
                    };

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

        public async Task SetUpProperties()
        {
            IsReviewNeededForCurrentSpec = false;

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

                IsReviewNeededForCurrentSpec = await SpecProcessAssignDataAccess.CheckIfReviewIsNeededForSpecId(CurrentSpec.Id);
            }
        }
    }
}