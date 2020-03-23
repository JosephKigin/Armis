using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.ProcessModels.Spec;
using ArmisWebsite.DataAccess.Process.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArmisWebsite.Pages.ProcessMaintenance
{
    public class SpecificationCreationModel : PageModel
    {
        //Data Access
        public ISpecDataAccess SpecDataAccess { get; set; }
        //Data Models 

        //Front-End Models
        [BindProperty]
        public int SpecId { get; set; } //This will only get a value if the current spec is being reved-up
        [BindProperty]
        public string SpecCode { get; set; }
        [BindProperty]
        public string SpecDescription { get; set; }
        [BindProperty]
        public string ExternalRev { get; set; }

        [BindProperty]
        public string SubLevelName1 { get; set; }
        [BindProperty]
        public List<string> ChoiceNames1 { get; set; }
        [BindProperty]
        public bool IsSubLevelReq1 { get; set; }
        [BindProperty]
        public byte? DefaultChoice1 { get; set; }


        public SpecificationCreationModel(ISpecDataAccess aSpecDataAccess)
        {
            SpecDataAccess = aSpecDataAccess;
        }

        public void OnGet()
        {

        }

        public async Task<ActionResult> OnPost()
        {
            var theSpec = new SpecModel()
            {
                Description = SpecDescription,
                ExternalRev = ExternalRev,
                Code = SpecCode
            };

            var theSubLevelList = new List<SpecSubLevelModel>(); //This will be assigned to theSpec.Sublevels at the end.

            if (SubLevelName1 != null)
            {
                var theSubLevel1 = new SpecSubLevelModel()
                {
                    Name = SubLevelName1,
                    LevelSeq = 1,
                    IsRequired = IsSubLevelReq1,
                    DefaultChoice = DefaultChoice1
                };

                if (ChoiceNames1 != null && ChoiceNames1.Any())
                {
                    var theChoices1 = new List<SpecSubLevelChoiceModel>();
                    for (byte i = 0; i < ChoiceNames1.Count; i++)
                    {
                        theChoices1.Add(new SpecSubLevelChoiceModel()
                        {
                            ChoiceSeq = i,
                            Name = ChoiceNames1[i]
                        });
                    }

                    theSubLevel1.Choices = theChoices1;
                }

                theSubLevelList.Add(theSubLevel1);
            }
            else
            {
                return Page(); //TODO can they enter a spec without any sublevels?
            }

            theSpec.SubLevels = theSubLevelList;

            if(SpecId == 0) //New Spec
            {
                await SpecDataAccess.CreateNewSpec(theSpec);
            }
            else //Spec is being reved-up
            {

            }

            return Page();
        }
    }
}
