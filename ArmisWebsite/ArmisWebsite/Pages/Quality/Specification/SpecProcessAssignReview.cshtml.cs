using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.QualityModels.Spec;
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

        //Model Properties
        public IEnumerable<SpecProcessAssignModel> AllSpecProcessAssigns { get; set; }

        //Front-End Properties
        [BindProperty]
        public List<string> SpecProcessAssignmentsToPost { get; set; }

        [BindProperty]
        public PopUpMessageModel Message { get; set; }

        public SpecProcessAssignReviewModel(ISpecProcessAssignDataAccess aSpecProcessAssignDataAccess)
        {
            SpecProcessAssignDataAccess = aSpecProcessAssignDataAccess;
        }

        public async Task<ActionResult> OnGet(string aMessage, bool isMessageGood)
        {
            try
            {
                if (aMessage != null)
                { Message = new PopUpMessageModel() { Text = aMessage, IsMessageGood = isMessageGood }; }

                await SetUpProperties();

                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error", new { ExMessage = ex.Message });
            }

        }

        public async Task<ActionResult> OnPostRemove()
        {
            try
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
            catch (Exception ex)
            {
                return RedirectToPage("/Error", new { ExMessage = ex.Message });
            }

        }

        public async Task<ActionResult> OnPostKeep()
        {
            try
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
            catch (Exception ex)
            {
                return RedirectToPage("/Error", new { ExMessage = ex.Message });
            }
        }

        public async Task SetUpProperties()
        {
            var tempSpecProcessAssign = await SpecProcessAssignDataAccess.GetAllReviewNeededSpecProcessAssign();
            AllSpecProcessAssigns = (tempSpecProcessAssign != null) ? tempSpecProcessAssign.ToList() : null;

            if (AllSpecProcessAssigns != null)
            {
                foreach (var assign in AllSpecProcessAssigns)
                {
                    assign.IsViable = await SpecProcessAssignDataAccess.CheckSpaIsViable(assign.SpecId, assign.ChoiceOptionId1 ?? 0, assign.ChoiceOptionId2 ?? 0, assign.ChoiceOptionId3 ?? 0, assign.ChoiceOptionId4 ?? 0, assign.ChoiceOptionId5 ?? 0, assign.ChoiceOptionId6 ?? 0);
                }
            }

        }
    }
}