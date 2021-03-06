﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.QualityModels.Process;
using ArmisWebsite.DataAccess.Quality.Interfaces;
using ArmisWebsite.FrontEndModels;
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
        [Required, Display(Name = "Name")]
        public string CurrentOperationName { get; set; }

        [BindProperty]
        [Required, StringLength(8), Display(Name = "Code")]
        public string CurrentOperationCode { get; set; }

        [BindProperty]
        [Required, Range(0, 32000), Display(Name = "Default Due Days")]
        public short? CurrentOperationDefaultDueDays { get; set; }

        [BindProperty]
        public bool CurrentOperationThicknessReq { get; set; }

        [BindProperty]
        [Required, Display(Name = "Group")]
        public int CurrentOperationGroupId { get; set; }

        public PopUpMessageModel Message { get; set; }

        public OperationMaintenanceModel(IOperationDataAccess anOperationDataAccess)
        {
            OperationDataAccess = anOperationDataAccess;
        }

        public async Task<ActionResult> OnGet(string aMessage, bool? isMessageGood, int anOperationId = 0)
        {
            await SetUpPageProperties(aMessage, isMessageGood, anOperationId);

            return Page();

        }

        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var theCurrentOperation = new OperationModel()
                {
                    Name = CurrentOperationName,
                    OperShortName = CurrentOperationCode,
                    DefaultDueDays = CurrentOperationDefaultDueDays,
                    ThicknessIsRequired = CurrentOperationThicknessReq,
                    OperationGroupId = CurrentOperationGroupId
                };

                var theReturnMessage = "";
                OperationModel result;

                if (CurrentOperationId == 0) //If the operation ID is 0, then a new operation is to be created
                {
                    result = await OperationDataAccess.CreateOperation(theCurrentOperation);

                    theReturnMessage = "New operation was created successfully.";
                }
                else //If the operation Id is not 0, then the operation with the ID selected is to be updated
                {
                    theCurrentOperation.Id = CurrentOperationId;

                    result = await OperationDataAccess.UpdateOperation(theCurrentOperation);

                    theReturnMessage = "The operation was updated successfully.";
                }

                return RedirectToPage("OperationMaintenance", new { anOperationId = result.Id, aMessage = theReturnMessage, isMessageGood = true });
            }

            await SetUpPageProperties();
            return Page();

        }

        public async Task SetUpPageProperties(string aMessage = null, bool? isMessageGood = null, int anOperationId = 0)
        {
            if (aMessage != null)
            {
                Message = new PopUpMessageModel()
                {
                    Text = aMessage,
                    IsMessageGood = isMessageGood
                };
            }


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
                CurrentOperationCode = theCurrentOperation.OperShortName;
                CurrentOperationDefaultDueDays = theCurrentOperation.DefaultDueDays;
                CurrentOperationThicknessReq = theCurrentOperation.ThicknessIsRequired;
                CurrentOperationGroupId = theCurrentOperation.Group.Id;
            }
        }
    }
}