using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.QualityModels.Spec;
using ArmisWebsite.DataAccess.Quality.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;
using ArmisWebsite.DataAccess.Quality.Inspection.Interfaces;
using ArmisWebsite.FrontEndModels;
using Armis.BusinessModels.QualityModels.InspectionModels;
using Armis.BusinessModels.QualityModels.Process;

namespace ArmisWebsite.Pages.ProcessMaintenance
{
    public class SpecificationMaintenanceModel : PageModel
    {
        //Data Access
        public ISpecDataAccess SpecDataAccess { get; set; }
        public ISamplePlanDataAccess SamplePlanDataAccess { get; set; }
        public IStepDataAccess StepDataAccess { get; set; }

        //Data Models 
        public List<SpecModel> AllSpecModels { get; set; }
        public List<SamplePlanModel> AllSamplePlans { get; set; }
        public List<StepModel> AllSteps { get; set; }
        public List<StepCategoryModel> AllStepCategories { get; set; }

        //Front-End Models
        public PopUpMessageModel Message { get; set; }
        //Current
        [BindProperty(SupportsGet = true)]
        public int CurrentSpecId { get; set; }//This will only get a value if the current spec is being reved-up
        [BindProperty]
        public string SpecCode { get; set; }
        [BindProperty]
        public string SpecDescription { get; set; }
        [BindProperty]
        public string ExternalRev { get; set; }
        [BindProperty]
        public bool WasRevUpSelected { get; set; }


        //Sublevel 1
        [BindProperty]
        public string SubLevelName1 { get; set; }
        [BindProperty]
        [Required]
        public List<SpecSubLevelChoiceModel> ChoiceList1 { get; set; }
        [BindProperty]
        public bool IsSubLevelReq1 { get; set; }
        [BindProperty]
        public byte? DefaultChoice1 { get; set; }

        //Sublevel 2
        [BindProperty]
        public string SubLevelName2 { get; set; }
        [BindProperty]
        public List<SpecSubLevelChoiceModel> ChoiceList2 { get; set; }
        [BindProperty]
        public bool IsSubLevelReq2 { get; set; }
        [BindProperty]
        public byte? DefaultChoice2 { get; set; }

        //Sublevel 3
        [BindProperty]
        public string SubLevelName3 { get; set; }
        [BindProperty]
        public List<SpecSubLevelChoiceModel> ChoiceList3 { get; set; }
        [BindProperty]
        public bool IsSubLevelReq3 { get; set; }
        [BindProperty]
        public byte? DefaultChoice3 { get; set; }

        //Sublevel 4
        [BindProperty]
        public string SubLevelName4 { get; set; }
        [BindProperty]
        public List<SpecSubLevelChoiceModel> ChoiceList4 { get; set; }
        [BindProperty]
        public bool IsSubLevelReq4 { get; set; }
        [BindProperty]
        public byte? DefaultChoice4 { get; set; }

        //Sublevel 5
        [BindProperty]
        public string SubLevelName5 { get; set; }
        [BindProperty]
        public List<SpecSubLevelChoiceModel> ChoiceList5 { get; set; }
        [BindProperty]
        public bool IsSubLevelReq5 { get; set; }
        [BindProperty]
        public byte? DefaultChoice5 { get; set; }

        //Sublevel 6
        [BindProperty]
        public string SubLevelName6 { get; set; }
        [BindProperty]
        public List<SpecSubLevelChoiceModel> ChoiceList6 { get; set; }
        [BindProperty]
        public bool IsSubLevelReq6 { get; set; }
        [BindProperty]
        public byte? DefaultChoice6 { get; set; }

        //Radio button for Sample Plan
        [BindProperty]
        public int? SamplePlanId { get; set; }

        public SpecificationMaintenanceModel(ISpecDataAccess aSpecDataAccess, ISamplePlanDataAccess aSamplePlanDataAccess, IStepDataAccess aStepDataAccess)
        {
            SpecDataAccess = aSpecDataAccess;
            SamplePlanDataAccess = aSamplePlanDataAccess;
            StepDataAccess = aStepDataAccess;
        }

        public async Task<IActionResult> OnGet(int? aSpecId, string aMessage = null)
        {
            try
            {
                Message = new PopUpMessageModel()
                {
                    Text = aMessage
                };
                if (aMessage != null) { Message.IsMessageGood = true; }

                if (aSpecId != 0 && aSpecId != null)
                {
                    if (CurrentSpecId == 0)
                    {
                        //?? is a null checker (null coalescing operator).  So if aSpecId is not null, it will be applied to CurrentSpecId.  If it is null (can't happen becuase if statement) CurrentSpecId = 0. This is needed otherwise it will complain that (int != int?).
                        CurrentSpecId = aSpecId ?? 0;
                    }

                }

                await SetUpProperties(CurrentSpecId);

                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error", new { ExMessage = ex.Message });
            }

        }

        public async Task<ActionResult> OnPost()
        {
            Message = new PopUpMessageModel();

            if (!ModelState.IsValid) //Is this even used?
            {
                Message.Text = ModelState.ToString();
                Message.IsMessageGood = false;
                
                return Page();
            }
            try
            {
                var theSpec = new SpecModel()
                {
                    Id = CurrentSpecId,
                    Code = SpecCode
                };

                var theSpecRev = new SpecRevModel()
                {
                    //Date & Time Modified will be set at the API level.
                    SpecId = CurrentSpecId,
                    Description = SpecDescription,
                    ExternalRev = ExternalRev,
                    EmployeeNumber = 941,
                    SamplePlanId = SamplePlanId
                };

                var theSubLevelList = new List<SpecSubLevelModel>(); //This will be assigned to theSpec.Sublevels at the end.

                byte subLevelSeq = 0;

                //Sublevel 1
                if (SubLevelName1 != null)
                {
                    subLevelSeq++;
                    theSubLevelList.Add(BuildSubLevelFromPage(subLevelSeq, SubLevelName1, ChoiceList1, IsSubLevelReq1, DefaultChoice1));
                }

                //Sublevel 2
                if (SubLevelName2 != null)
                {
                    subLevelSeq++;
                    theSubLevelList.Add(BuildSubLevelFromPage(subLevelSeq, SubLevelName2, ChoiceList2, IsSubLevelReq2, DefaultChoice2));
                }

                //Sublevel 3
                if (SubLevelName3 != null)
                {
                    subLevelSeq++;
                    theSubLevelList.Add(BuildSubLevelFromPage(subLevelSeq, SubLevelName3, ChoiceList3, IsSubLevelReq3, DefaultChoice3));
                }

                //Sublevel 4
                if (SubLevelName4 != null)
                {
                    subLevelSeq++;
                    theSubLevelList.Add(BuildSubLevelFromPage(subLevelSeq, SubLevelName4, ChoiceList4, IsSubLevelReq4, DefaultChoice4));
                }

                //Sublevel 5
                if (SubLevelName5 != null)
                {
                    subLevelSeq++;
                    theSubLevelList.Add(BuildSubLevelFromPage(subLevelSeq, SubLevelName5, ChoiceList5, IsSubLevelReq5, DefaultChoice5));
                }

                //Sublevel 6
                if (SubLevelName6 != null)
                {
                    subLevelSeq++;
                    theSubLevelList.Add(BuildSubLevelFromPage(subLevelSeq, SubLevelName6, ChoiceList6, IsSubLevelReq6, DefaultChoice6));
                }


                theSpecRev.SubLevels = theSubLevelList;
                var theSpecRevsTempList = new List<SpecRevModel>();
                theSpecRevsTempList.Add(theSpecRev); //This is just a list of one to hold the rev because Specification Model takes a list of revs, not just one. 
                theSpec.SpecRevModels = theSpecRevsTempList;
                var theReturnedSpecId = 0;  //This is the SpecId that will be returned from the DataAccess after creating a new Spec or Reving up a Spec.
                if (CurrentSpecId == 0) //New Spec
                {
                    theReturnedSpecId = await SpecDataAccess.CreateNewHydratedSpec(theSpec);
                    CurrentSpecId = theReturnedSpecId;
                    Message.Text = "Spec created successfully.";
                    Message.IsMessageGood = true;
                }
                else if (WasRevUpSelected) //Spec is being Reved-Up.
                {
                    theSpec.Id = CurrentSpecId;
                    theReturnedSpecId = await SpecDataAccess.RevUpSpec(theSpecRev);
                    Message.Text = "Spec reved-up successfully";
                    Message.IsMessageGood = true;
                }
                await SetUpProperties(theReturnedSpecId);
                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error", new { ExMessage = ex.Message });
            }
        }

        //As of now, this will only get hit if a spec id is passed into the page.
        public async Task SetUpProperties(int? aSpecId)
        {
            if (aSpecId != null && aSpecId != 0)
            {
                int theSpecId = aSpecId ?? default(int); //The spec id passed into SpecDataAccess.GetHydratedCurrentRevOfSpec needs to be of type int, not int?
                var theCurrentSpec = await SpecDataAccess.GetHydratedCurrentRevOfSpec(theSpecId);
                var theCurrentSpecRev = theCurrentSpec.SpecRevModels.FirstOrDefault();

                SpecCode = theCurrentSpec.Code;
                SpecDescription = theCurrentSpecRev.Description;
                ExternalRev = theCurrentSpecRev.ExternalRev;
                SamplePlanId = theCurrentSpecRev.SamplePlanId;

                theCurrentSpecRev.SubLevels.OrderBy(i => i.LevelSeq);

                foreach (var sublevel in theCurrentSpecRev.SubLevels)
                {
                    BuildPageFromModels(sublevel);
                }
            }

            var tempAllSpecModels = await SpecDataAccess.GetAllHydratedSpecs();
            AllSpecModels = tempAllSpecModels.ToList();

            var tempAllSamplePlanModels = await SamplePlanDataAccess.GetAllHydratedSamplePlans();
            AllSamplePlans = tempAllSamplePlanModels.ToList();

            var tempAllStepModels = await StepDataAccess.GetAllSteps();
            AllSteps = tempAllStepModels.ToList();

            var tempAllStepCategoryModels = await StepDataAccess.GetAllStepCategoryies();
            AllStepCategories = tempAllStepCategoryModels.ToList();
        }

        //This method loads up some models to be added into a spec.  This is used in the default OnPost.
        public SpecSubLevelModel BuildSubLevelFromPage(byte aSubLevelSeq, string aSubLevelName, List<SpecSubLevelChoiceModel> aChoiceList, bool anIsSubLevelReq, byte? aDefaultChoice)
        {
            var theSubLevel = new SpecSubLevelModel()
            {
                Name = aSubLevelName,
                LevelSeq = aSubLevelSeq,
                IsRequired = anIsSubLevelReq,
                DefaultChoice = aDefaultChoice
            };

            if (aChoiceList != null && aChoiceList.Any())
            {
                for (byte i = 0; i < aChoiceList.Count; i++) //Goes through each choice for the sublevel and assigns the choice a choice seq id and the sublevel id
                {
                    aChoiceList[i].ChoiceSeqId = (byte)(i + 1);
                    aChoiceList[i].SubLevelSeqId = aSubLevelSeq;
                }
                theSubLevel.Choices = aChoiceList;
            }

            return theSubLevel;
        }

        //All 6 sections are written out seperately.  TODO: this might be able to be cut down significantly using reflection, typeof, and property searches.
        public void BuildPageFromModels(SpecSubLevelModel aSubLevel)
        {
            switch (aSubLevel.LevelSeq)
            {
                case 1:
                    SubLevelName1 = aSubLevel.Name;
                    IsSubLevelReq1 = aSubLevel.IsRequired;
                    DefaultChoice1 = aSubLevel.DefaultChoice;
                    ChoiceList1 = new List<SpecSubLevelChoiceModel>();
                    aSubLevel.Choices.OrderBy(i => i.ChoiceSeqId);
                    foreach (var choice in aSubLevel.Choices)
                    {
                        ChoiceList1.Add(choice);
                    }
                    break;
                case 2:
                    SubLevelName2 = aSubLevel.Name;
                    IsSubLevelReq2 = aSubLevel.IsRequired;
                    DefaultChoice2 = aSubLevel.DefaultChoice;
                    ChoiceList2 = new List<SpecSubLevelChoiceModel>();
                    aSubLevel.Choices.OrderBy(i => i.ChoiceSeqId);
                    foreach (var choice in aSubLevel.Choices)
                    {
                        ChoiceList2.Add(choice);
                    }
                    break;
                case 3:
                    SubLevelName3 = aSubLevel.Name;
                    IsSubLevelReq3 = aSubLevel.IsRequired;
                    DefaultChoice3 = aSubLevel.DefaultChoice;
                    ChoiceList3 = new List<SpecSubLevelChoiceModel>();
                    aSubLevel.Choices.OrderBy(i => i.ChoiceSeqId);
                    foreach (var choice in aSubLevel.Choices)
                    {
                        ChoiceList3.Add(choice);
                    }
                    break;
                case 4:
                    SubLevelName4 = aSubLevel.Name;
                    IsSubLevelReq4 = aSubLevel.IsRequired;
                    DefaultChoice4 = aSubLevel.DefaultChoice;
                    ChoiceList4 = new List<SpecSubLevelChoiceModel>();
                    aSubLevel.Choices.OrderBy(i => i.ChoiceSeqId);
                    foreach (var choice in aSubLevel.Choices)
                    {
                        ChoiceList4.Add(choice);
                    }
                    break;
                case 5:
                    SubLevelName5 = aSubLevel.Name;
                    IsSubLevelReq5 = aSubLevel.IsRequired;
                    DefaultChoice5 = aSubLevel.DefaultChoice;
                    ChoiceList5 = new List<SpecSubLevelChoiceModel>();
                    aSubLevel.Choices.OrderBy(i => i.ChoiceSeqId);
                    foreach (var choice in aSubLevel.Choices)
                    {
                        ChoiceList5.Add(choice);
                    }
                    break;

                case 6:
                    SubLevelName6 = aSubLevel.Name;
                    IsSubLevelReq6 = aSubLevel.IsRequired;
                    DefaultChoice6 = aSubLevel.DefaultChoice;
                    ChoiceList6 = new List<SpecSubLevelChoiceModel>();
                    aSubLevel.Choices.OrderBy(i => i.ChoiceSeqId);
                    foreach (var choice in aSubLevel.Choices)
                    {
                        ChoiceList6.Add(choice);
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
