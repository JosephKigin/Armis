using Armis.BusinessModels.QualityModels.Spec;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.QualityExtensions.SpecExtensions;
using Armis.DataLogic.Services.QualityServices.Inspection.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.QualityServices.Inspection
{
     public class SamplePlanService : ISamplePlanService
    {
        private ARMISContext Context;

        public SamplePlanService(ARMISContext aContext)
        {
            Context = aContext;
        }

        //CREATE
        public async Task<SamplePlanModel> CreateSamplePlan(SamplePlanModel aSamplePlan)
        {
            var lastUsedSamplePlanId = await Context.SamplePlanHead.MaxAsync(s => s.SamplePlanId);
            //Should the extensions handle loading up all the entities, or should ToEntity be called on all the different levels right here? (Sample Plan, level, and reject)
            //Probaby the second option because the level will need a LevelId assigned to it based on how many levels are in the Sample Plan.
            Context.SamplePlanHead.Add(aSamplePlan.ToHydratedEntity());

            return null;
        }

        //READ
        public async Task<IEnumerable<SamplePlanModel>> GetAllSamplePlans()
        {
            var entities = await Context.SamplePlanHead.ToListAsync();

            if(entities == null || !entities.Any()) { throw new Exception("No Sample Plans were returned."); }

            return entities.ToModels();
        }

        public async Task<IEnumerable<SamplePlanModel>> GetAllHydratedSamplePlans()
        {
            var entities = await Context.SamplePlanHead.Include(h => h.SamplePlanLevel).ThenInclude(l => l.SamplePlanReject).ThenInclude(r => r.InspectTest).ToListAsync();

            if(entities == null || !entities.Any()) { throw new Exception("No Sample Plans were returned."); }

            return entities.ToHydratedModels();
        }
    }
}
