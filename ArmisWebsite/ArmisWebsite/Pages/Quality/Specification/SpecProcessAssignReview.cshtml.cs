using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.QualityModels.Process;
using Armis.BusinessModels.QualityModels.Spec;
using ArmisWebsite.DataAccess.Quality;
using ArmisWebsite.DataAccess.Quality.Interfaces;
using ArmisWebsite.DataAccess.Quality.Specification.Interfaces;
using ArmisWebsite.FrontEndModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArmisWebsite.Pages.Quality.Specification
{
    public class SpecProcessAssignReviewModel : PageModel
    {
        //Data Access
        public ISpecProcessAssignDataAccess SpecProcessAssignDataAccess { get; set; }
        public ISpecDataAccess SpecDataAccess { get; set; }
        public IProcessDataAccess ProcessDataAccess { get; set; }

        //Model Properties
        public List<SpecProcessAssignModel> AllSpecProcessAssigns { get; set; }
        public List<int> AllSpecIds { get; set; } //Unique list of all spec Ids that have assignments that need review
        public List<SpecRevModel> AllNewSpecs { get; set; } //Stores any new specs that caused the SPAs to go under review
        public List<ProcessRevisionModel> AllNewProcessRevModel { get; set; } //Stores any new processes that caused the SPAs to go under review


        //Front-End Properties
        [BindProperty]
        public List<string> SpecProcessAssignmentsToPost { get; set; }

        [BindProperty]
        public PopUpMessageModel Message { get; set; }

        public SpecProcessAssignReviewModel(ISpecProcessAssignDataAccess aSpecProcessAssignDataAccess, ISpecDataAccess aSpecDataAccess, IProcessDataAccess aProcessDataAccess)
        {
            SpecProcessAssignDataAccess = aSpecProcessAssignDataAccess;
            SpecDataAccess = aSpecDataAccess;
            ProcessDataAccess = aProcessDataAccess;
        }

        public async Task<ActionResult> OnGet(string aMessage, bool isMessageGood)
        {
            if (aMessage != null)
            { Message = new PopUpMessageModel() { Text = aMessage, IsMessageGood = isMessageGood }; }

            await SetUpProperties();

            return Page();
        }

        public async Task<ActionResult> OnPostRemove()
        {
            if (SpecProcessAssignmentsToPost != null && SpecProcessAssignmentsToPost.Any())
            {
                await SetUpProperties(); //This is called here so AllSpecProcessAssigns is available to find the assignment(s) being sent back to the API.
                foreach (var assignment in SpecProcessAssignmentsToPost)
                {
                    var allIds = assignment.Split("-"); //This will be a list of 3 ids: specId, specRevId, specAssignId seperated by a "-"
                    var specId = int.Parse(allIds[0]);
                    var specRevId = int.Parse(allIds[1]);
                    var specAssignId = int.Parse(allIds[2]);

                    var theSpecProcessAssignToRemove = AllSpecProcessAssigns.FirstOrDefault(i => i.SpecId == specId && i.SpecRevId == specRevId && i.SpecAssignId == specAssignId);
                    await SpecProcessAssignDataAccess.RemoveReviedNeeded(theSpecProcessAssignToRemove);
                }

                Message = new PopUpMessageModel()
                {
                    IsMessageGood = true,
                    Text = "Specification-Process Assignments inactivated successfully"
                };
            }

            await SetUpProperties(); //This is called again to update the ReviewNeeded list because some were just removed based on the stuff above.

            return Page();
        }

        public async Task<ActionResult> OnPostKeep()
        {
            if (SpecProcessAssignmentsToPost != null && SpecProcessAssignmentsToPost.Any())
            {
                await SetUpProperties();

                foreach (var assignment in SpecProcessAssignmentsToPost)
                {
                    var allIds = assignment.Split("-"); //This will be a list of 3 ids: specId, specRevId, specAssignId seperated by a "-"
                    var specId = int.Parse(allIds[0]);
                    var specRevId = int.Parse(allIds[1]);
                    var specAssignId = int.Parse(allIds[2]);

                    var theSpecProcessAssignToRemove = AllSpecProcessAssigns.FirstOrDefault(i => i.SpecId == specId && i.SpecRevId == specRevId && i.SpecAssignId == specAssignId);
                    await SpecProcessAssignDataAccess.CopyAfterReview(theSpecProcessAssignToRemove);
                }

                Message = new PopUpMessageModel()
                {
                    IsMessageGood = true,
                    Text = "Specification-Process Assignments updated with new revisions successfully"
                };

                return RedirectToPage("SpecProcessAssignReview", new { aMessage = "Specification-Process Assignments updated with new revisions successfully", isMessageGood = true });
            }

            return RedirectToPage("SpecProcessAssignReview", new { aMessage = "Nothing was selected", isMessageGood = false });
        }

        public async Task SetUpProperties()
        {
            AllNewSpecs = new List<SpecRevModel>();
            AllNewProcessRevModel = new List<ProcessRevisionModel>();
            AllSpecIds = new List<int>();

            var tempSpecProcessAssign = await SpecProcessAssignDataAccess.GetAllHydratedReviewNeededSpecProcessAssign();
            AllSpecProcessAssigns = (tempSpecProcessAssign != null) ? tempSpecProcessAssign.ToList() : null;

            if (AllSpecProcessAssigns != null)
            {
                foreach (var specProcessAssign in AllSpecProcessAssigns)
                {
                    if (!AllSpecIds.Contains(specProcessAssign.SpecId))
                    { AllSpecIds.Add(specProcessAssign.SpecId); }
                }

                foreach (var assign in AllSpecProcessAssigns)
                {
                    //Finding out if the spec is under review because of a spec rev up or a process rev up.
                    var theNewestSpecRev = (await SpecDataAccess.GetHydratedCurrentRevOfSpec(assign.SpecId)).SpecRevModels.FirstOrDefault();
                    if (theNewestSpecRev.InternalRev != assign.SpecRevId)
                    {
                        assign.IsViable = false;
                        if(!AllNewSpecs.Contains(theNewestSpecRev))
                        { AllNewSpecs.Add(theNewestSpecRev); }
                    }

                    var theNewestProcessRev = await ProcessDataAccess.GetHydratedCurrentProcessRev(assign.ProcessId);
                    if (theNewestProcessRev.ProcessRevId != assign.ProcessRevId)
                    { AllNewProcessRevModel.Add(theNewestProcessRev); }
                }
            }

        }
    }
}