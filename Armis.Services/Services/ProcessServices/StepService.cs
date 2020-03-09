using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.ModelExtensions.ProcessExtensions;
using Armis.DataLogic.Services.ProcessServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ProcessServices
{
    public class StepService : IStepService
    {
        private ARMISContext Context;

        public StepService(ARMISContext aContext)
        {
            Context = aContext;
        }

        //CREATE
        public async Task<int> CreateStep(StepModel aStepModel)
        {
            if (aStepModel == null) { throw new NullReferenceException("No step model was given."); }

            var theStepEntity = aStepModel.ToEntity();

            var theLastStepIdUsed = await Context.Step.MaxAsync(i => i.StepId);

            theStepEntity.StepId = theLastStepIdUsed + 1;

            Context.Step.Add(theStepEntity);
            await Context.SaveChangesAsync();

            return theStepEntity.StepId;
        }

        public async Task<IEnumerable<StepModel>> GetAll()
        {
            var theStepEntities = await Context.Step.ToListAsync();

            if (theStepEntities == null || !theStepEntities.Any()) { throw new NullReferenceException("No steps were returned."); }

            var theStepModels = new List<StepModel>();

            foreach (var step in theStepEntities)
            {
                theStepModels.Add(step.ToHydratedModel());
            }

            return theStepModels;
        }

        public async Task<StepModel> GetStepById(int aStepId)
        {
            var theStepEntity = await Context.Step.SingleOrDefaultAsync(i => i.StepId == aStepId);

            if (theStepEntity == null) { throw new NullReferenceException("There is no step with that ID."); }

            return theStepEntity.ToHydratedModel();
        }

        //This should realistically only return one step because the fron-end forces names to be unique
        public async Task<List<StepModel>> GetStepByName(string aStepName)
        {
            var theStepEntities = await Context.Step.Where(i => i.StepName == aStepName).ToListAsync();

            if (theStepEntities == null) { throw new NullReferenceException("There is no step with that name."); }

            var result = new List<StepModel>();

            foreach (var step in theStepEntities) { result.Add(step.ToHydratedModel()); }

            return result;
        }

        //READ
        public async Task<IEnumerable<StepModel>> GetAllByCategory(string aCategory)
        {
            var theStepEntities = await Context.Step.Where(i => i.StepCategoryCd == aCategory).ToListAsync();

            if (theStepEntities == null || !theStepEntities.Any()) { throw new NullReferenceException("No steps returned that belong to " + aCategory + "."); }

            var theStepModels = new List<StepModel>();

            foreach (var step in theStepEntities)
            {
                theStepModels.Add(step.ToModel());
            }

            return theStepModels;
        }

        //UPDATE
        public async Task<int> DeactivateStep(int aStepId) //TODO: Update this after step table has been updated
        {
            var theStepToDelete = await Context.Step.SingleOrDefaultAsync(i => i.StepId == aStepId);

            Context.Step.Remove(theStepToDelete);
            await Context.SaveChangesAsync();

            return theStepToDelete.StepId;
        }

        public async Task<int> UpdateStep(int aStepId, StepModel aStepModel) //TODO: Update this when step table is updated.
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
