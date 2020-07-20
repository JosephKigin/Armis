using Armis.BusinessModels.QualityModels.Spec;
using Armis.Data.DatabaseContext;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.ModelExtensions.CustomerExtensions;
using Armis.DataLogic.ModelExtensions.QualityExtensions.SpecExtensions;
using Armis.DataLogic.Services.QualityServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            await Context.SpecSubLevel.LoadAsync();
            await Context.SpecChoice.LoadAsync();
            var theSpecProcessAssignEntities = await Context.SpecProcessAssign.IncludeOptimized(i => i.Spec) //This is acutally Spec Rev
                                                                              .IncludeOptimized(i => i.CustomerNavigation)
                                                                              .IncludeOptimized(i => i.Process) //This is actually Process Rev
                                                                              .IncludeOptimized(i => i.SpecProcessAssignOption)
                                                                              .ToListAsync();

            if (theSpecProcessAssignEntities == null || !theSpecProcessAssignEntities.Any()) { throw new Exception("No Process-Spec Assignments returned."); }

            return theSpecProcessAssignEntities.ToHydratedModels();
        }

        public async Task<IEnumerable<SpecProcessAssignModel>> GetAllActiveHydratedSpecProcessAssign()
        {
            await Context.SpecSubLevel.LoadAsync();
            await Context.SpecChoice.LoadAsync();
            await Context.Step.Where(i => i.StepCategoryId == 1 || i.StepCategoryId == 2).LoadAsync(); //1 is BAKE, 2 is MASK
            var theSpecProcessAssignEntities = await Context.SpecProcessAssign.Where(i => i.Inactive == false)
                                                                              .IncludeOptimized(i => i.Spec)
                                                                              .IncludeOptimized(i => i.CustomerNavigation)
                                                                              .IncludeOptimized(i => i.Process)
                                                                              .IncludeOptimized(i => i.SpecProcessAssignOption)
                                                                              .ToListAsync();

            if (theSpecProcessAssignEntities == null || !theSpecProcessAssignEntities.Any()) { throw new Exception("No Process-Spec Assignments returned."); }

            var result = theSpecProcessAssignEntities.ToHydratedModels();

            //Process and Customer are not part of the model extension for specProcessAssign.ToModel(), so they are both pulled and loaded into the model here.  This is because of all the addition ThenIncludes that would be necessary to load all the information into one entity variable.
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

        public async Task<IEnumerable<SpecProcessAssignModel>> GetAllActiveHydratedSpecProcessAssignForSpec(int aSpecId)
        {
            await Context.SpecChoice.LoadAsync();
            await Context.SpecSubLevel.LoadAsync();
            await Context.Step.Where(i => i.StepCategoryId == 1 || i.StepCategoryId == 2).LoadAsync(); //1 is BAKE, 2 is MASK
            //This will always pull the most recent rev because the most recent will always be the active.
            var theSpecProcessAssignEntities = await Context.SpecProcessAssign.Where(i => i.Inactive == false && i.SpecId == aSpecId)
                                                                              .IncludeOptimized(i => i.Spec)
                                                                              .IncludeOptimized(i => i.CustomerNavigation)
                                                                              .IncludeOptimized(i => i.Process)
                                                                              .IncludeOptimized(i => i.SpecProcessAssignOption)
                                                                              .ToListAsync();

            if (theSpecProcessAssignEntities == null || !theSpecProcessAssignEntities.Any()) { return null; }

            var result = theSpecProcessAssignEntities.ToHydratedModels();

            //Process and Customer are not part of the model extension for specProcessAssign.ToModel(), so they are both pulled and loaded into the model here.  This is because of all the addition ThenIncludes that would be necessary to load all the information into one entity variable. 
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

        public async Task<IEnumerable<SpecProcessAssignModel>> GetAllHydratedReviewNeeded() //TODO: Test later when there are some review needed entries in the database.
        {
            await Context.SpecChoice.LoadAsync();
            await Context.SpecSubLevel.LoadAsync();
            await Context.Step.Where(i => i.StepCategoryId == 1 || i.StepCategoryId == 2).LoadAsync(); //1 is BAKE, 2 is MASK
            var theSpecProcessAssignEntities = await Context.SpecProcessAssign.Where(i => i.ReviewNeeded == true)
                                                                              .IncludeOptimized(i => i.Spec)
                                                                              .IncludeOptimized(i => i.CustomerNavigation)
                                                                              .IncludeOptimized(i => i.Process)
                                                                              .IncludeOptimized(i => i.SpecProcessAssignOption)
                                                                              .ToListAsync();

            if (theSpecProcessAssignEntities == null || !theSpecProcessAssignEntities.Any()) { return null; }  //This call needs to be able to return null because there may not be any SpecProcessAssignments to review.

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

        public async Task<SpecProcessAssignModel> CopyAfterReview(SpecProcessAssignModel aSpecProcessAssignModel) //This will be the old SpecProcessAssignModel so the AssignId will need to be updated.  "Keep" on the front-end
        {
            using (var transaction = await Context.Database.BeginTransactionAsync())
            {
                await RemoveReviewNeeded(aSpecProcessAssignModel.SpecId, aSpecProcessAssignModel.SpecRevId, aSpecProcessAssignModel.SpecAssignId);

                var mostRecentSpecRevId = (await Context.SpecificationRevision.Where(i => i.SpecId == aSpecProcessAssignModel.SpecId).OrderByDescending(i => i.SpecRevId).FirstOrDefaultAsync()).SpecRevId;
                var mostRecentProcessRevId = (await Context.ProcessRevision.Where(i => i.ProcessId == aSpecProcessAssignModel.ProcessId).OrderByDescending(i => i.ProcessRevId).FirstOrDefaultAsync()).ProcessRevId;

                aSpecProcessAssignModel.SpecRevId = mostRecentSpecRevId;
                aSpecProcessAssignModel.ProcessRevId = mostRecentProcessRevId;

                //Pulls all assignments that have the same specId and specRevId (which will be the SPA "Family") as the assignment being copied.
                var specProcessAssignFamily = await Context.SpecProcessAssign.Where(i => i.SpecId == aSpecProcessAssignModel.SpecId &&
                                                                                   i.SpecRevId == mostRecentSpecRevId).ToListAsync();

                if (specProcessAssignFamily == null || !specProcessAssignFamily.Any()) //There aren't any previous assigns for this spec/spec rev
                { 
                    aSpecProcessAssignModel.SpecAssignId = 1;
                    foreach (var option in aSpecProcessAssignModel.SpecProcessAssignOptionModels) //Update options for options
                    { option.SpecAssignId = 1; }
                }
                else //There are assign Ids already for this spec/spec rev
                {
                    var lastAssignIdUsed = specProcessAssignFamily.OrderByDescending(i => i.SpecAssignId).FirstOrDefault().SpecAssignId;
                    aSpecProcessAssignModel.SpecAssignId = (lastAssignIdUsed + 1);
                    foreach (var option in aSpecProcessAssignModel.SpecProcessAssignOptionModels) //Update options for options
                    { option.SpecAssignId = (lastAssignIdUsed + 1); }
                }

                aSpecProcessAssignModel.Inactive = false;
                aSpecProcessAssignModel.IsReviewNeeded = false;

                Context.SpecProcessAssign.Add(aSpecProcessAssignModel.ToEntity());
                await Context.SaveChangesAsync();
                await transaction.CommitAsync();

                return aSpecProcessAssignModel;
            }
        }

        public async Task<bool> CheckSpaIsViable(int aSpecId, IEnumerable<SpecProcessAssignOptionModel> anOptionModels)
        {
            bool isViable = true;

            var currentRev = await Context.SpecificationRevision.Where(i => i.SpecId == aSpecId).MaxAsync(i => i.SpecRevId);

            var currentChocies = await Context.SpecChoice.Where(i => i.SpecId == aSpecId && i.SpecRevId == currentRev).ToListAsync();

            foreach (var option in anOptionModels)
            {
                if (currentChocies.FirstOrDefault(i => i.SubLevelSeqId == option.SubLevelSeqId && i.ChoiceSeqId == option.ChoiceSeqId) == null)
                {
                    isViable = false;
                }
            }

            return isViable;
        }

        public async Task<SpecProcessAssignModel> RemoveReviewNeeded(int aSpecId, short aSpecRevId, int anAssignId)
        {
            var specProcessAssignEntity = await Context.SpecProcessAssign.FirstOrDefaultAsync(i => i.SpecId == aSpecId && i.SpecRevId == aSpecRevId && i.SpecAssignId == anAssignId);

            if (specProcessAssignEntity == null) { throw new Exception("No Spec-Process Assignment was found"); }

            specProcessAssignEntity.ReviewNeeded = false;

            Context.Update(specProcessAssignEntity);
            await Context.SaveChangesAsync();

            return specProcessAssignEntity.ToModel();
        }

        public async Task<bool> CheckIfReviewIsNeededForSpecId(int aSpecId)
        {
            var spaEntities = await Context.SpecProcessAssign.Where(i => i.SpecId == aSpecId).ToListAsync();

            bool isReviewNeeded = false;

            foreach (var spa in spaEntities)
            {
                if (spa.ReviewNeeded)
                { isReviewNeeded = true; }
            }

            return isReviewNeeded;
        }

        public async Task<bool> VerifyUniqueChoices(int specId, short internalSpecRev, int? customer, IEnumerable<SpecProcessAssignOptionModel> anOptionModels)
        {
            bool isUnique = true;

            var existingSpaEntities = await Context.SpecProcessAssign.IncludeOptimized(i => i.SpecProcessAssignOption).Where(i => i.SpecId == specId &&
                                                                                  i.SpecRevId == internalSpecRev &&
                                                                                  i.Customer == customer).ToListAsync();

            if (existingSpaEntities != null) //There is already at least one SPA with the same SpecId, RevId, and Customer.  If it is null, then the options are good to go!
            {
                //Converting the options passed in into a string
                string theOptionsConcatenated = "";
                if (anOptionModels != null)
                {
                    foreach (var option in anOptionModels)
                    { theOptionsConcatenated += option.SubLevelSeqId + "-" + option.ChoiceSeqId + ":"; }
                }

                foreach (var entity in existingSpaEntities)
                {
                    if (!isUnique) { continue; } //Skip through iterating anymore if isUnique is ever false because it has already failed the check.
                    if ((entity.SpecProcessAssignOption == null || !entity.SpecProcessAssignOption.Any()) && (anOptionModels == null || !anOptionModels.Any())) //If the entity has null/empty options AND the options passed in is null/empty, not unique!
                    {
                        isUnique = false;
                    }
                    else
                    {
                        //Converting the current entity's options into a string
                        string currentOptionsConcatenated = "";
                        foreach (var option in entity.SpecProcessAssignOption)
                        { currentOptionsConcatenated += option.SubLevelSeqId + "-" + option.ChoiceSeqId + ":"; }
                        if (theOptionsConcatenated == currentOptionsConcatenated)
                        {
                            isUnique = false;
                        }
                    }

                }
            }

            return isUnique;
        }
    }
}
