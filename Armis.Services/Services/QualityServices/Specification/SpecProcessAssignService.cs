﻿using Armis.BusinessModels.QualityModels.Spec;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.CustomerExtensions;
using Armis.DataLogic.ModelExtensions.QualityExtensions.SpecExtensions;
using Armis.DataLogic.Services.QualityServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Armis.DataLogic.Services.QualityServices
{
    public class SpecProcessAssignService : ISpecProcessAssignService
    {
        private ARMISContext Context;

        public SpecProcessAssignService(ARMISContext aContext)
        {
            Context = aContext;
        }

        //CREATE
        public async Task<SpecProcessAssignModel> PostSpecProcessAssign(SpecProcessAssignModel aSpecProcessAssignModel) //The model that gets passed in is returned with an updated SpecAssignId
        {
            int theNewSpecAssignId;
            var theCurrenSpecProcessAssigns = await Context.SpecProcessAssign.Where(i => i.SpecId == aSpecProcessAssignModel.SpecId && i.SpecRevId == aSpecProcessAssignModel.SpecRevId).ToListAsync();
            if (theCurrenSpecProcessAssigns != null && theCurrenSpecProcessAssigns.Any()) { theNewSpecAssignId = (theCurrenSpecProcessAssigns.OrderByDescending(i => i.SpecAssignId).FirstOrDefault().SpecAssignId) + 1; }
            else { theNewSpecAssignId = 1; }
            aSpecProcessAssignModel.SpecAssignId = theNewSpecAssignId;
            var theSpecProcessAssignEntity = aSpecProcessAssignModel.ToEntity();

            Context.SpecProcessAssign.Add(theSpecProcessAssignEntity);
            await Context.SaveChangesAsync();

            return aSpecProcessAssignModel;
        }

        //READ

        public async Task<IEnumerable<SpecProcessAssignModel>> GetAllHydratedSpecProcessAssign()
        {

            var theSpecProcessAssignEntities = await Context.SpecProcessAssign.Include(i => i.SpecChoiceNavigation)
                                                                              .Include(i => i.SpecChoice)
                                                                              .Include(i => i.SpecChoice1)
                                                                              .Include(i => i.SpecChoice2)
                                                                              .Include(i => i.SpecChoice3)
                                                                              .Include(i => i.SpecChoice4)
                                                                              .Include(i => i.PreBakeOptionNavigation.StepCategory)
                                                                              .Include(i => i.PostBakeOptionNavigation.StepCategory)
                                                                              .Include(i => i.MaskOptionNavigation.StepCategory)
                                                                              .Include(i => i.HardnessOptionNavigation)
                                                                              .Include(i => i.SeriesOptionNavigation)
                                                                              .Include(i => i.AlloyOptionNavigation)
                                                                              .Include(i => i.CustomerNavigation)
                                                                              .Include(i => i.Process)
                                                                              .ToListAsync();

            if (theSpecProcessAssignEntities == null || !theSpecProcessAssignEntities.Any()) { throw new Exception("No Process-Spec Assignments returned."); }

            return theSpecProcessAssignEntities.ToHydratedModels();
        }

        public async Task<IEnumerable<SpecProcessAssignModel>> GetAllActiveHydratedSpecProcessAssign()
        {
            var theSpecProcessAssignEntities = await Context.SpecProcessAssign.Where(i => i.Inactive == false)
                                                                              .IncludeOptimized(i => i.Spec)
                                                                              .IncludeOptimized(i => i.SpecChoiceNavigation)
                                                                              .IncludeOptimized(i => i.SpecChoice)
                                                                              .IncludeOptimized(i => i.SpecChoice1)
                                                                              .IncludeOptimized(i => i.SpecChoice2)
                                                                              .IncludeOptimized(i => i.SpecChoice3)
                                                                              .IncludeOptimized(i => i.SpecChoice4)
                                                                              .IncludeOptimized(i => i.PreBakeOptionNavigation.StepCategory)
                                                                              .IncludeOptimized(i => i.PostBakeOptionNavigation.StepCategory)
                                                                              .IncludeOptimized(i => i.MaskOptionNavigation.StepCategory)
                                                                              .IncludeOptimized(i => i.HardnessOptionNavigation)
                                                                              .IncludeOptimized(i => i.SeriesOptionNavigation)
                                                                              .IncludeOptimized(i => i.AlloyOptionNavigation)
                                                                              .IncludeOptimized(i => i.CustomerNavigation)
                                                                              .IncludeOptimized(i => i.Process)
                                                                              .ToListAsync();

            if (theSpecProcessAssignEntities == null || !theSpecProcessAssignEntities.Any()) { throw new Exception("No Process-Spec Assignments returned."); }

            var result = theSpecProcessAssignEntities.ToHydratedModels();

            //Process and Customer are not part of the model extension for specProcessAssign.ToModel(), so they are both pulled and loaded into the model here.
            foreach (var model in result)
            {
                model.ProcessRevision.ProcessName = (await Context.Process.FirstOrDefaultAsync(i => i.ProcessId == model.ProcessRevision.ProcessId)).Name;
                model.SpecificationRevision.SpecCode = (await Context.Specification.FirstOrDefaultAsync(i => i.SpecId == model.SpecificationRevision.SpecId)).SpecCode;
                if (model.CustomerId != null)
                {
                    var tempCust = (await Context.Customer.FirstOrDefaultAsync(i => i.CustId == model.CustomerId));
                    model.Customer = tempCust.ToModel();
                }

            }

            return result;
        }

        public async Task<SpecProcessAssignModel> GetSpecProcessAssign(int aSpecId, short aSpecRevId, short aSpecAssignId)
        {
            var theSpecProcesAssignEntity = await Context.SpecProcessAssign.FirstOrDefaultAsync(i => i.SpecId == aSpecId && i.SpecRevId == aSpecRevId && i.SpecAssignId == aSpecAssignId);

            if (theSpecProcesAssignEntity == null) { throw new Exception("No Spec Process Assignment was found."); }

            return theSpecProcesAssignEntity.ToModel();
        }

        public async Task<IEnumerable<SpecProcessAssignModel>> GetAllHydratedReviewNeeded()
        {
            var theSpecProcessAssignEntities = await Context.SpecProcessAssign.Where(i => i.ReviewNeeded == true)
                                                                              .IncludeOptimized(i => i.Spec)
                                                                              .IncludeOptimized(i => i.SpecChoiceNavigation)
                                                                              .IncludeOptimized(i => i.SpecChoice)
                                                                              .IncludeOptimized(i => i.SpecChoice1)
                                                                              .IncludeOptimized(i => i.SpecChoice2)
                                                                              .IncludeOptimized(i => i.SpecChoice3)
                                                                              .IncludeOptimized(i => i.SpecChoice4)
                                                                              .IncludeOptimized(i => i.PreBakeOptionNavigation.StepCategory)
                                                                              .IncludeOptimized(i => i.PostBakeOptionNavigation.StepCategory)
                                                                              .IncludeOptimized(i => i.MaskOptionNavigation.StepCategory)
                                                                              .IncludeOptimized(i => i.HardnessOptionNavigation)
                                                                              .IncludeOptimized(i => i.SeriesOptionNavigation)
                                                                              .IncludeOptimized(i => i.AlloyOptionNavigation)
                                                                              .IncludeOptimized(i => i.CustomerNavigation)
                                                                              .IncludeOptimized(i => i.Process)
                                                                              .ToListAsync();

            if (theSpecProcessAssignEntities == null || !theSpecProcessAssignEntities.Any()) { return null; }  //This call needs to be able to return null because there may not be any SpecProcessAssignments to review.

            var result = theSpecProcessAssignEntities.ToHydratedModels();

            //Process and Customer are not part of the model extension for specProcessAssign.ToModel(), so they are both pulled and loaded into the model here.
            foreach (var model in result)
            {
                model.ProcessRevision.ProcessName = (await Context.Process.FirstOrDefaultAsync(i => i.ProcessId == model.ProcessRevision.ProcessId)).Name;
                if (model.CustomerId != null)
                {
                    var tempCust = (await Context.Customer.FirstOrDefaultAsync(i => i.CustId == model.CustomerId));
                    model.Customer = tempCust.ToModel();
                }

            }

            return result;
        }

        //public async Task<SpecProcessAssignModel> 

        public async Task<SpecProcessAssignModel> RemoveReviewNeeded(int aSpecId, short aSpecRevId, int anAssignId)
        {
            var specProcessAssignEntity = await Context.SpecProcessAssign.FirstOrDefaultAsync(i => i.SpecId == aSpecId && i.SpecRevId == aSpecRevId && i.SpecAssignId == anAssignId);

            if(specProcessAssignEntity == null) { throw new Exception("No Spec-Process Assignment was found"); }

            specProcessAssignEntity.ReviewNeeded = false;

            Context.Update(specProcessAssignEntity);
            await Context.SaveChangesAsync();

            return specProcessAssignEntity.ToModel();
        }

        public async Task<bool> VerifyUniqueChoices(int specId, short internalSpecRev, int? choice1, int? choice2, int? choice3, int? choice4, int? choice5, int? choice6, int? preBake, int? postBake, int? mask, int? hardness, int? series, int? alloy, int? customer)
        {
            var entity = await Context.SpecProcessAssign.FirstOrDefaultAsync(i => i.SpecId == specId &&
                                                                                  i.SpecRevId == internalSpecRev &&
                                                                                  i.ChoiceOption1 == choice1 &&
                                                                                  i.ChoiceOption2 == choice2 &&
                                                                                  i.ChoiceOption3 == choice3 &&
                                                                                  i.ChoiceOption4 == choice4 &&
                                                                                  i.ChoiceOption5 == choice5 &&
                                                                                  i.ChoiceOption6 == choice6 &&
                                                                                  i.PreBakeOption == preBake &&
                                                                                  i.PostBakeOption == postBake &&
                                                                                  i.MaskOption == mask &&
                                                                                  i.HardnessOption == hardness &&
                                                                                  i.SeriesOption == series &&
                                                                                  i.AlloyOption == alloy &&
                                                                                  i.Customer == customer);

            if (entity == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
