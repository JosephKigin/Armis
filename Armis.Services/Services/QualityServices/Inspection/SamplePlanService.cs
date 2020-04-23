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
