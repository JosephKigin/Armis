﻿using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext;
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

        public async Task<IEnumerable<StepModel>> GetAll()
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
                theStepModels.Add(step.ToModel(0));  //There is no sequence needed at this point, so a 0 is passed in for sequence number
            }

            return theStepModels;
        }

        public async Task<IEnumerable<StepModel>> GetAllByCategory(string aCategory)
        {
            var theStepEntities = await Context.Step.Where(i => i.StepCategoryCd == aCategory).ToListAsync();

            if(theStepEntities == null || !theStepEntities.Any()) { throw new NullReferenceException("No steps returned that belong to " + aCategory + "."); }

            var theStepModels = new List<StepModel>();

            foreach (var step in theStepEntities)
            {
                theStepModels.Add(step.ToModel(0));
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
    }
}
