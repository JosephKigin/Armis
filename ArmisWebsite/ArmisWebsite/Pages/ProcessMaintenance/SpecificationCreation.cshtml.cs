using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.ProcessModels.Spec;
using ArmisWebsite.DataAccess.Process.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace ArmisWebsite.Pages.ProcessMaintenance
{
    public class SpecificationCreationModel : PageModel
    {
        //Data Access
        public ISpecDataAccess SpecDataAccess { get; set; }
        //Data Models 
        public List<SpecModel> AllSpecModels { get; set; }

        //Front-End Models
        public string PopUpMessage { get; set; }
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
        public List<string> ChoiceNames1 { get; set; }
        [BindProperty]
        public bool IsSubLevelReq1 { get; set; }
        [BindProperty]
        public byte? DefaultChoice1 { get; set; }

        //Sublevel 2
        [BindProperty]
        public string SubLevelName2 { get; set; }
        [BindProperty]
        public List<string> ChoiceNames2 { get; set; }
        [BindProperty]
        public bool IsSubLevelReq2 { get; set; }
        [BindProperty]
        public byte? DefaultChoice2 { get; set; }

        //Sublevel 3
        [BindProperty]
        public string SubLevelName3 { get; set; }
        [BindProperty]
        public List<string> ChoiceNames3 { get; set; }
        [BindProperty]
        public bool IsSubLevelReq3 { get; set; }
        [BindProperty]
        public byte? DefaultChoice3 { get; set; }

        //Sublevel 4
        [BindProperty]
        public string SubLevelName4 { get; set; }
        [BindProperty]
        public List<string> ChoiceNames4 { get; set; }
        [BindProperty]
        public bool IsSubLevelReq4 { get; set; }
        [BindProperty]
        public byte? DefaultChoice4 { get; set; }

        //Sublevel 5
        [BindProperty]
        public string SubLevelName5 { get; set; }
        [BindProperty]
        public List<string> ChoiceNames5 { get; set; }
        [BindProperty]
        public bool IsSubLevelReq5 { get; set; }
        [BindProperty]
        public byte? DefaultChoice5 { get; set; }

        //Sublevel 6
        [BindProperty]
        public string SubLevelName6 { get; set; }
        [BindProperty]
        public List<string> ChoiceNames6 { get; set; }
        [BindProperty]
        public bool IsSubLevelReq6 { get; set; }
        [BindProperty]
        public byte? DefaultChoice6 { get; set; }

        public SpecificationCreationModel(ISpecDataAccess aSpecDataAccess)
        {
            SpecDataAccess = aSpecDataAccess;
        }

        public async Task<IActionResult> OnGet(int? aSpecId, string aPopUpMessage = null)
        {
            try
            {
                PopUpMessage = aPopUpMessage;
                //TODO: aSpecId shouldn't actually be used anymore, this needs to be removed and cleaned up.
                if (aSpecId != 0 && aSpecId != null)
                {
                    if (CurrentSpecId == 0)
                    {
                        //?? is a null checker (null coalescing operator).  So if aSpecId is not null, it will be applied to CurrentSpecId.  If it is null (can't happen becuase if statement) CurrentSpecId = 0. 
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
            if (!ModelState.IsValid)
            {
                PopUpMessage = ModelState.ToString();
                return Page();
            }
            try
            {
                var theSpec = new SpecModel()
                {
                    Description = SpecDescription,
                    ExternalRev = ExternalRev,
                    Code = SpecCode
                };

                var theSubLevelList = new List<SpecSubLevelModel>(); //This will be assigned to theSpec.Sublevels at the end.

                byte subLevelSeq = 0;

                //Sublevel 1
                if (SubLevelName1 != null)
                {
                    subLevelSeq++;
                    theSubLevelList.Add(BuildSubLevelFromPage(subLevelSeq, SubLevelName1, ChoiceNames1, IsSubLevelReq1, DefaultChoice1));
                }

                //Sublevel 2
                if (SubLevelName2 != null)
                {
                    subLevelSeq++;
                    theSubLevelList.Add(BuildSubLevelFromPage(subLevelSeq, SubLevelName2, ChoiceNames2, IsSubLevelReq2, DefaultChoice2));
                }

                //Sublevel 3
                if (SubLevelName3 != null)
                {
                    subLevelSeq++;
                    theSubLevelList.Add(BuildSubLevelFromPage(subLevelSeq, SubLevelName3, ChoiceNames3, IsSubLevelReq3, DefaultChoice3));
                }

                //Sublevel 4
                if (SubLevelName4 != null)
                {
                    subLevelSeq++;
                    theSubLevelList.Add(BuildSubLevelFromPage(subLevelSeq, SubLevelName4, ChoiceNames4, IsSubLevelReq4, DefaultChoice4));
                }

                //Sublevel 5
                if (SubLevelName5 != null)
                {
                    subLevelSeq++;
                    theSubLevelList.Add(BuildSubLevelFromPage(subLevelSeq, SubLevelName5, ChoiceNames5, IsSubLevelReq5, DefaultChoice5));
                }

                //Sublevel 6
                if (SubLevelName6 != null)
                {
                    subLevelSeq++;
                    theSubLevelList.Add(BuildSubLevelFromPage(subLevelSeq, SubLevelName6, ChoiceNames6, IsSubLevelReq6, DefaultChoice6));
                }


                theSpec.SubLevels = theSubLevelList;
                var theReturnedSpecId = 0;  //This is the SpecId that will be returned from the DataAccess after creating a new Spec or Reving up a Spec.
                if (CurrentSpecId == 0) //New Spec
                {
                    theReturnedSpecId = await SpecDataAccess.CreateNewHydratedSpec(theSpec);
                    await SetUpProperties(theReturnedSpecId);
                    PopUpMessage = "Spec created successfully.";
                }
                else if (WasRevUpSelected) //Spec is being updated. Only stuff under the spec level can be updated.  If anything on the Spec level is updated, then it should just be a new Revision.
                {
                    //TODO: This section is for rev-up
                    theSpec.Id = CurrentSpecId;
                    theReturnedSpecId = await SpecDataAccess.RevUpSpec(theSpec);
                    await SetUpProperties(theReturnedSpecId);
                    PopUpMessage = "Spec reved-up successfully";
                }

                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error", new { ExMessage = ex.Message }); //TODO:: Insert logging here.
            }
        }

        //As of now, this will only get hit if a spec id is passed into the page.
        public async Task SetUpProperties(int? aSpecId)
        {
            if (aSpecId != null && aSpecId != 0)
            {
                int theSpecId = aSpecId ?? default(int); //The spec id passed into SpecDataAccess.GetHydratedCurrentRevOfSpec needs to be of type int, not int?
                var theCurrentSpec = await SpecDataAccess.GetHydratedCurrentRevOfSpec(theSpecId);

                SpecCode = theCurrentSpec.Code;
                SpecDescription = theCurrentSpec.Description;
                ExternalRev = theCurrentSpec.ExternalRev;

                theCurrentSpec.SubLevels.OrderBy(i => i.LevelSeq);

                foreach (var sublevel in theCurrentSpec.SubLevels)
                {
                    BuildPageFromModels(sublevel);
                }
            }

            var tempAllSpecModels = await SpecDataAccess.GetAllHydratedSpecsWithOnlyCurrentRev();
            AllSpecModels = tempAllSpecModels.ToList();

        }

        //This method loads up some models to be added into a spec.  This is used in the default OnPost so far.
        public SpecSubLevelModel BuildSubLevelFromPage(byte aSubLevelSeq, string aSubLevelName, List<string> aChoiceNamesList, bool anIsSubLevelReq, byte? aDefaultChoice)
        {
            var theSubLevel = new SpecSubLevelModel()
            {
                Name = aSubLevelName,
                LevelSeq = aSubLevelSeq,
                IsRequired = anIsSubLevelReq,
                DefaultChoice = aDefaultChoice
            };

            if (aChoiceNamesList != null && aChoiceNamesList.Any())
            {
                var theChoices = new List<SpecSubLevelChoiceModel>();
                byte choiceCount = 0; //Keeps track of seq for choices.
                for (byte i = 0; i < aChoiceNamesList.Count; i++)
                {
                    if (aChoiceNamesList[i] != null)
                    {
                        choiceCount++;
                        theChoices.Add(new SpecSubLevelChoiceModel()
                        {
                            ChoiceSeq = choiceCount,
                            Name = aChoiceNamesList[i]
                        });
                    }

                }

                theSubLevel.Choices = theChoices;
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
                    ChoiceNames1 = new List<string>();
                    aSubLevel.Choices.OrderBy(i => i.ChoiceSeq);
                    foreach (var choice in aSubLevel.Choices)
                    {
                        ChoiceNames1.Add(choice.Name);
                    }
                    break;
                case 2:
                    SubLevelName2 = aSubLevel.Name;
                    IsSubLevelReq2 = aSubLevel.IsRequired;
                    DefaultChoice2 = aSubLevel.DefaultChoice;
                    ChoiceNames2 = new List<string>();
                    aSubLevel.Choices.OrderBy(i => i.ChoiceSeq);
                    foreach (var choice in aSubLevel.Choices)
                    {
                        ChoiceNames2.Add(choice.Name);
                    }
                    break;
                case 3:
                    SubLevelName3 = aSubLevel.Name;
                    IsSubLevelReq3 = aSubLevel.IsRequired;
                    DefaultChoice3 = aSubLevel.DefaultChoice;
                    ChoiceNames3 = new List<string>();
                    aSubLevel.Choices.OrderBy(i => i.ChoiceSeq);
                    foreach (var choice in aSubLevel.Choices)
                    {
                        ChoiceNames3.Add(choice.Name);
                    }
                    break;
                case 4:
                    SubLevelName4 = aSubLevel.Name;
                    IsSubLevelReq4 = aSubLevel.IsRequired;
                    DefaultChoice4 = aSubLevel.DefaultChoice;
                    ChoiceNames4 = new List<string>();
                    aSubLevel.Choices.OrderBy(i => i.ChoiceSeq);
                    foreach (var choice in aSubLevel.Choices)
                    {
                        ChoiceNames4.Add(choice.Name);
                    }
                    break;
                case 5:
                    SubLevelName5 = aSubLevel.Name;
                    IsSubLevelReq5 = aSubLevel.IsRequired;
                    DefaultChoice5 = aSubLevel.DefaultChoice;
                    ChoiceNames5 = new List<string>();
                    aSubLevel.Choices.OrderBy(i => i.ChoiceSeq);
                    foreach (var choice in aSubLevel.Choices)
                    {
                        ChoiceNames5.Add(choice.Name);
                    }
                    break;

                case 6:
                    SubLevelName6 = aSubLevel.Name;
                    IsSubLevelReq6 = aSubLevel.IsRequired;
                    DefaultChoice6 = aSubLevel.DefaultChoice;
                    ChoiceNames6 = new List<string>();
                    aSubLevel.Choices.OrderBy(i => i.ChoiceSeq);
                    foreach (var choice in aSubLevel.Choices)
                    {
                        ChoiceNames6.Add(choice.Name);
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
