using Armis.BusinessModels.QualityModels.Process;
using Armis.Data.DatabaseContext;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.ModelExtensions.QualityExtensions.ProcessExtensions;
using Armis.DataLogic.Services.QualityServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.QualityServices
{
    public class StepService : IStepService
    {
        private ARMISContext Context;

        public StepService(ARMISContext aContext)
        {
            Context = aContext;
        }

        //CREATE
        public async Task<StepModel> CreateStep(StepModel aStepModel)
        {
            if (aStepModel == null) { throw new NullReferenceException("No step model was given."); }

            var theLastStepIdUsed = await Context.Step.MaxAsync(i => i.StepId);
            aStepModel.StepId = theLastStepIdUsed + 1;
            
            var theStepEntity = aStepModel.ToEntity();
            Context.Step.Add(theStepEntity);
            await Context.SaveChangesAsync();

            return aStepModel;
        }

        //READ
        public async Task<IEnumerable<StepModel>> GetAll()
        {
            var theStepEntities = await Context.Step.Include(i => i.StepCategory).ToListAsync();

            if (theStepEntities == null || !theStepEntities.Any()) { throw new NullReferenceException("No steps were returned."); }

            var theStepModels = theStepEntities.ToModels();

            return theStepModels;
        }

        public async Task<StepModel> GetStepById(int aStepId)
        {
            var theStepEntity = await Context.Step.Where(i => i.StepId == aStepId).Include(i => i.StepCategory).FirstOrDefaultAsync();

            if (theStepEntity == null) { throw new NullReferenceException("There is no step with that ID."); }

            return theStepEntity.ToModel();
        }

        //This should realistically only return one step because the fron-end forces names to be unique
        public async Task<List<StepModel>> GetStepByName(string aStepName)
        {
            var theStepEntities = await Context.Step.Where(i => i.StepName == aStepName).Include(i => i.StepCategory).ToListAsync();

            if (theStepEntities == null) { throw new NullReferenceException("There is no step with that name."); }

            var result = new List<StepModel>();

            foreach (var step in theStepEntities) { result.Add(step.ToModel()); }

            return result;
        }

        public async Task<IEnumerable<StepModel>> GetAllByCategory(string aCategory)
        {
            var theStepEntities = await Context.Step.Where(i => i.StepCategory.Code.ToLower() == aCategory.ToLower()).Include(i => i.StepCategory).ToListAsync();

            if (theStepEntities == null || !theStepEntities.Any()) { throw new NullReferenceException("No steps returned that belong to " + aCategory + "."); }

            var theStepModels = new List<StepModel>();

            foreach (var step in theStepEntities)
            {
                theStepModels.Add(step.ToModel());
            }

            return theStepModels;
        }

        public async Task<IEnumerable<StepCategoryModel>> GetAllStepCategories()
        {
            var theCategoryEntities = await Context.StepCategory.ToListAsync();

            var resultModels = theCategoryEntities.ToModels();

            return resultModels;
        }

        public async Task<StepCategoryModel> GetStepCategoryById(short aStepCategoryId)
        {
            var theStepCategoryEntity = await Context.StepCategory.FindAsync(aStepCategoryId);

            if (theStepCategoryEntity == null) { throw new Exception("No step category with that ID exists."); }

            return theStepCategoryEntity.ToModel();
        }

        //UPDATE
        public async Task<int> DeactivateStep(int aStepId) 
        {
            var theStepToDelete = await Context.Step.SingleOrDefaultAsync(i => i.StepId == aStepId);

            Context.Step.Remove(theStepToDelete);
            await Context.SaveChangesAsync();

            return theStepToDelete.StepId;
        }

        public async Task<int> UpdateStep(int aStepId, StepModel aStepModel)
        {
            var theStepEntityToChange = await Context.Step.SingleOrDefaultAsync(i => i.StepId == aStepId);

            if (theStepEntityToChange == null) { throw new NullReferenceException("There is currently no Step with that Id in the database."); }

            var theNewStepEntity = aStepModel.ToEntity();

            Context.Update(theStepEntityToChange);
            await Context.SaveChangesAsync();

            return theStepEntityToChange.StepId;
        }

        //DELETE
        //Steps are never deleted!
    }
}
