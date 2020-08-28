using Armis.BusinessModels.QualityModels.InspectionModels;
using Armis.BusinessModels.QualityModels.Spec;
using Armis.Data.DatabaseContext;
using Armis.Data.DatabaseContext.Entities;
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
            using (var transaction = await Context.Database.BeginTransactionAsync())
            {
                var newSamplePlanId = (await Context.SamplePlanHead.MaxAsync(s => s.SamplePlanId)) + 1;

                await Context.SamplePlanHead.AddAsync(aSamplePlan.ToEntity(newSamplePlanId));
                await Context.SamplePlanLevel.AddRangeAsync(aSamplePlan.SamplePlanLevelModels.ToEntities(newSamplePlanId));

                var tempSamplePlanRejectEntities = new List<SamplePlanReject>();
                foreach (var levelModel in aSamplePlan.SamplePlanLevelModels)
                {
                    await Context.AddRangeAsync(levelModel.SamplePlanRejectModels.ToEntities(newSamplePlanId));
                }

                await Context.SaveChangesAsync();
                await transaction.CommitAsync();

                //Goes back to the database and returns the fully hydrated Sample Plan it just created.  This is done so the user on the front-end can verify that the data got into the database correctly.
                return (await Context.SamplePlanHead.Where(i => i.SamplePlanId == newSamplePlanId)
                                                        .Include(h => h.SamplePlanLevel)
                                                            .ThenInclude(l => l.SamplePlanReject)
                                                                .ThenInclude(r => r.InspectTest).FirstOrDefaultAsync()).ToHydratedModel(); ;
            }
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

        public async Task<bool> CheckIfNameIsUnique(string aName)
        {
            var entity = await Context.SamplePlanHead.FirstOrDefaultAsync(i => i.PlanName == aName);

            if(entity != null) { return false; }
            else { return true; }
        }
    }
}
