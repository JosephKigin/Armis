using Armis.BusinessModels.ProcessModels.Spec;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.ProcessExtensions.SpecExtensions;
using Armis.DataLogic.Services.ProcessServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ProcessServices
{
    public class SpecService : ISpecService
    {
        private ARMISContext context;

        public SpecService(ARMISContext aContext)
        {
            context = aContext;
        }

        public async Task<IEnumerable<SpecModel>> GetAllHydratedSpecs()
        {
            var entities = await context.Specification
                                            .Include(i => i.SpecSubLevel)
                                                .ThenInclude(i => i.SpecChoice)
                                                    .ToListAsync();

            if(entities == null || !entities.Any()) { throw new Exception("No Specs were returned."); }

            return entities.ToHydratedModels();
        }

        public async Task<IEnumerable<SpecSubLevelModel>> GetSpecSubLevels(int aSpecId, short aSpecRevId)
        {
            var entities = await context.SpecSubLevel.Where(i => i.SpecId == aSpecId && i.SpecRevId == aSpecRevId)
                                                        .Include(i => i.SpecChoice)
                                                        .ToListAsync();

            if(entities == null || !entities.Any()) { return null; }

            return entities.ToHydratedModels();
        }
    }
}
