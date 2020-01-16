﻿using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.ModelExtensions.ProcessExtensions;
using Armis.DataLogic.ProcessServices.Interfaces;
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
        private ARMISContext _context;

        public ARMISContext Context
        {
            get { return _context; }
            set { _context = value; }
        }

        public StepService(ARMISContext aContext)
        {
            Context = aContext;
        }

        public async Task<int> CreateStep(StepModel aStepModel)
        {
            if(aStepModel == null) { throw new NullReferenceException("No step model was given."); }

            var theStepEntity = aStepModel.ToEntity();

            var theLastStepIdUsed = await Context.Step.MaxAsync(i => i.StepId);

            theStepEntity.StepId = theLastStepIdUsed + 1;

            Context.Step.Add(theStepEntity);
            await Context.SaveChangesAsync();

            return theStepEntity.StepId;
        }

        public async Task<int> DeactivateStep(int aStepId) //TODO: Update this after step table has been updated
        {
            var theStepToDelete = await Context.Step.SingleOrDefaultAsync(i => i.StepId == aStepId);

            Context.Step.Remove(theStepToDelete);
            await Context.SaveChangesAsync();

            return theStepToDelete.StepId;
        }

        public async Task<IEnumerable<StepModel>> GetAllHydrated()
        {
            var theStepEntities = await Context.Step
                                        .Include(i => i.StepVarSeq)
                                            .ThenInclude(j => j.StepVariable)
                                                .ThenInclude(m => m.UomcdNavigation)
                                        .Include(i => i.StepVarSeq)
                                            .ThenInclude(j => j.StepVariable)
                                                .ThenInclude(k => k.VarTempCdNavigation)
                                                    .ThenInclude(l => l.StepVarTypeCdNavigation).ToListAsync();

            if(theStepEntities == null || !theStepEntities.Any()) { throw new NullReferenceException("No steps were returned."); }

            var theStepModels = new List<StepModel>();

            foreach (var step in theStepEntities)
            {
                theStepModels.Add(step.ToModel());
            }

            return theStepModels;
        }

        public async Task<StepModel> GetHydratedStepById(int aStepId)
        {
            var theStepEntity = await Context.Step.Where(i => i.StepId == aStepId)
                                                  .Include(i => i.StepVarSeq)
                                                    .ThenInclude(j => j.StepVariable)
                                                        .ThenInclude(m => m.UomcdNavigation)
                                                  .Include(i => i.StepVarSeq)
                                                    .ThenInclude(j => j.StepVariable)
                                                        .ThenInclude(k => k.VarTempCdNavigation)
                                                            .ThenInclude(l => l.StepVarTypeCdNavigation)
                                                  .SingleOrDefaultAsync();

            if (theStepEntity == null) { throw new NullReferenceException("There is no step with that ID."); }

            return theStepEntity.ToModel();
        }

        public async Task<IEnumerable<StepModel>> GetAllByCategory(string aCategory)
        {
            var theStepEntities = await Context.Step.Where(i => i.StepCategoryCd == aCategory).ToListAsync();

            if(theStepEntities == null || !theStepEntities.Any()) { throw new NullReferenceException("No steps returned that belong to " + aCategory + "."); }

            var theStepModels = new List<StepModel>();

            foreach (var step in theStepEntities)
            {
                theStepModels.Add(step.ToModel());
            }

            return theStepModels;
        }

        public async Task<int> UpdateStep(int aStepId, StepModel aStepModel) //TODO: Update this when step table is updated.
        {
            var theStepEntityToChange = await Context.Step.SingleOrDefaultAsync(i => i.StepId == aStepId);

            if(theStepEntityToChange == null) { throw new NullReferenceException("There is currently no Step with that Id in the database."); }

            var theNewStepEntity = aStepModel.ToEntity();

            Context.Update(theStepEntityToChange);
            await Context.SaveChangesAsync();

            return theStepEntityToChange.StepId;
        }

        public async Task<int> AddVariablesToStep(StepModel aStepModel)
        {
            var variableEntitiesToAdd = new List<StepVariable>();

            foreach (var model in aStepModel.Variables)
            {
                variableEntitiesToAdd.Add(model.ToEntity());
            }

            var stepVarSeqEntities = await Context.StepVarSeq.Where(i => i.StepId == aStepModel.StepId ).ToListAsync();
            var lastVariableIDUsed = await Context.StepVariable.MaxAsync(i => i.StepVariableId);
            short nextSeqNum = 1;

            if(stepVarSeqEntities != null && stepVarSeqEntities.Any())
            {
                nextSeqNum = stepVarSeqEntities.Max(i => i.VariableSeq);
                nextSeqNum++;
            }

            foreach (var entity in variableEntitiesToAdd)
            {
                var existingVariableEntity = await Context.StepVariable.FirstOrDefaultAsync(i => i.DefaultMin == entity.DefaultMin &&
                                                                                            i.DefaultMax == entity.DefaultMax &&
                                                                                            i.Uomcd == entity.Uomcd &&
                                                                                            i.VarTempCd == entity.VarTempCd);

                if(existingVariableEntity != null) { entity.StepVariableId = existingVariableEntity.StepVariableId; }
                else
                {                    
                    entity.StepVariableId = lastVariableIDUsed + 1;
                    lastVariableIDUsed++;
                    Context.StepVariable.Add(entity);
                }

                Context.StepVarSeq.Add(new StepVarSeq {StepId = aStepModel.StepId, StepVariableId = entity.StepVariableId, VariableSeq = nextSeqNum });
                nextSeqNum++;
            }
            await Context.SaveChangesAsync();
            return aStepModel.StepId;
        }
    }
}
