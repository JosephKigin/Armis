﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.QualityModels.Process;
using ArmisWebsite.DataAccess.Quality.Interfaces;
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
        [Required, Display(Name = "Operation Name")]
        public string CurrentOperationName { get; set; }

        [BindProperty]
        [Required, StringLength(8), Display(Name = "Operation Code")]
        public string CurrentOperationCode { get; set; }

        [BindProperty]
        [Required, Range(0, 32000), Display(Name = "Default Due Days")]
        public short? CurrentOperationDefaultDueDays { get; set; }

        [BindProperty]
        public bool CurrentOperationThicknessReq { get; set; }

        [BindProperty]
        [Required, Display(Name = "Operation Group")]
        public string CurrentOperationGroupName { get; set; }

        [BindProperty]
        public int CurrentOperationGroupId { get; set; }

        public string PopUpMessage { get; set; }

        public OperationMaintenanceModel(IOperationDataAccess anOperationDataAccess)
        {
            OperationDataAccess = anOperationDataAccess;
        }

        public async Task<ActionResult> OnGet(int anOperationId = 0, string aPopUpMessage = "")
        {
            try
            {
                PopUpMessage = aPopUpMessage;
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

                var theReturnMessage = "";
                OperationModel result;

                if (CurrentOperationId == 0) //If the operation ID is 0, then a new operation is to be created
                {
                    result = await OperationDataAccess.CreateOperation(theCurrentOperation);

                    await SetUpPageProperties(result.Id);

                    theReturnMessage = "New operation was created successfully.";
                }
                else //If the operation Id is not 0, then the operation with the ID selected is to be updated
                {
                    theCurrentOperation.Id = CurrentOperationId;

                    result = await OperationDataAccess.UpdateOperation(theCurrentOperation);

                    await SetUpPageProperties(result.Id);

                    theReturnMessage = "The operation was updated successfully.";
                }

                return RedirectToPage("OperationMaintenance", new { anOperationId = result.Id, aPopUpMessage = theReturnMessage});
            }

            await SetUpPageProperties();
            return Page();

        }

        public async Task SetUpPageProperties(int anOperationId = 0)
        {
            try
            {
                var theAllOperationsTemp = await OperationDataAccess.GetAllOperations();
                AllOperations = theAllOperationsTemp.OrderBy(i => i.Name).ToList();

                var theAllOperationGroupsTemp = await OperationDataAccess.GetAllOperationGroups();
                AllOperationGroups = theAllOperationGroupsTemp.OrderBy(i => i.Name).ToList();

                //Writing all the values for the current operation to the bound properties.
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