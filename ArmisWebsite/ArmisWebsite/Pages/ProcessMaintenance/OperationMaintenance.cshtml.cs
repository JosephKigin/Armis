using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.ProcessModels;
using ArmisWebsite.DataAccess.Process.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArmisWebsite
{
    public class OperationMaintenanceModel : PageModel
    {
        //Data Access
        public IOperationDataAccess OperationDataAccess { get; set; }

        //Model Properties
        public List<OperationModel> AllOperations { get; set; }

        [BindProperty]
        public List<OperationGroupModel> AllOperationGroups { get; set; }

        //Front-End Properties
        [BindProperty]
        public int CurrentOperationId { get; set; }

        [BindProperty]
        [Required]
        public string CurrentOperationName { get; set; }

        [BindProperty]
        [Required, StringLength(8)]
        public string CurrentOperationCode { get; set; }

        [BindProperty]
        [Required, Range(0, 32000)]
        public short? CurrentOperationDefaultDueDays { get; set; }

        [BindProperty]
        public bool CurrentOperationThicknessReq { get; set; }

        [BindProperty]
        public string CurrentOperationGroupName { get; set; }

        [BindProperty]
        public int CurrentOperationGroupId { get; set; }

        public string PopUpMessage { get; set; }

        public OperationMaintenanceModel(IOperationDataAccess anOperationDataAccess)
        {
            OperationDataAccess = anOperationDataAccess;
        }

        public async Task<ActionResult> OnGet(int anOperationId = 0)
        {
            try
            {
                await SetUpPageProperties(anOperationId);

                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error", new { ExMessage = ex.Message });
            }

        }

        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var theCurrentOperation = new OperationModel()
                {
                    Name = CurrentOperationName,
                    Code = CurrentOperationCode,
                    DefaultDueDays = CurrentOperationDefaultDueDays,
                    ThicknessIsRequired = CurrentOperationThicknessReq,
                    Group = new OperationGroupModel() { Id = CurrentOperationGroupId, Name = CurrentOperationGroupName }
                };

                if (CurrentOperationId == 0) //If the operation ID is 0, then a new operation is to be created
                {
                    var result = await OperationDataAccess.CreateOperation(theCurrentOperation);

                    await SetUpPageProperties(result.Id);

                    PopUpMessage += "New operation was created successfully.";
                }
                else //If the operation Id is not 0, then the operation with the ID selected is to be updated
                {
                    theCurrentOperation.Id = CurrentOperationId;

                    var result = await OperationDataAccess.UpdateOperation(theCurrentOperation);

                    await SetUpPageProperties(result.Id);

                    PopUpMessage += "The operation was updated successfully.";
                }

                return Page();
            }

            await SetUpPageProperties();
            PopUpMessage += "The information entered was not valid.";
            return Page();

        }

        public async Task SetUpPageProperties(int anOperationId = 0)
        {
            try
            {
                var theAllOperationsTemp = await OperationDataAccess.GetAllOperations();
                AllOperations = theAllOperationsTemp.ToList();

                var theAllOperationGroupsTemp = await OperationDataAccess.GetAllOperationGroups();
                AllOperationGroups = theAllOperationGroupsTemp.OrderByDescending(i => i.Name).ToList();

                if (anOperationId != 0)
                {
                    var theCurrentOperation = AllOperations.FirstOrDefault(i => i.Id == anOperationId);
                    CurrentOperationId = theCurrentOperation.Id;
                    CurrentOperationName = theCurrentOperation.Name;
                    CurrentOperationCode = theCurrentOperation.Code;
                    CurrentOperationDefaultDueDays = theCurrentOperation.DefaultDueDays;
                    CurrentOperationThicknessReq = theCurrentOperation.ThicknessIsRequired;
                    CurrentOperationGroupId = theCurrentOperation.Group.Id;
                    CurrentOperationGroupName = theCurrentOperation.Group.Name;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}