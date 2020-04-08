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

            if (entities == null || !entities.Any()) { throw new Exception("No Specs were returned."); }

            return entities.ToHydratedModels();
        }

        public async Task<IEnumerable<SpecModel>> GetAllHydratedSpecsWithOnlyCurrentRev()
        {
            var allSpecEntities = await context.Specification.Include(i => i.SpecSubLevel).ThenInclude(i => i.SpecChoice).ToListAsync();
            var uniqueSpecIds = allSpecEntities.Select(i => i.SpecId).Distinct();
            var specModels = new List<SpecModel>();

            foreach (var specId in uniqueSpecIds)
            {
                specModels.Add(allSpecEntities.Where(i => i.SpecId == specId).OrderByDescending(s => s.SpecRevId).FirstOrDefault().ToHydratedModel());
            }

            return specModels;
        }

        public async Task<IEnumerable<SpecSubLevelModel>> GetSpecSubLevels(int aSpecId, short aSpecRevId)
        {
            var entities = await context.SpecSubLevel.Where(i => i.SpecId == aSpecId && i.SpecRevId == aSpecRevId)
                                                        .Include(i => i.SpecChoice)
                                                        .ToListAsync();

            if (entities == null || !entities.Any()) { return null; }

            return entities.ToHydratedModels();
        }

        public async Task<SpecModel> GetCurrentRevForSpec(int aSpecId)
        {
            var entity = await context.Specification.Where(i => i.SpecId == aSpecId).OrderByDescending(i => i.SpecRevId)
                                                        .Include(i => i.SpecSubLevel)
                                                            .ThenInclude(i => i.SpecChoice)
                                                            .FirstOrDefaultAsync();
            if (entity == null) { return null; }

            return entity.ToHydratedModel();
        }

        public async Task<int> CreateNewSpec(SpecModel aSpecModel)
        {
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                var theNewSpecId = await context.Specification.MaxAsync(i => i.SpecId) + 1;
                short theNewRevId = 10; //All new specs start with a revId of 10

                var theSubLevelEntities = aSpecModel.SubLevels.ToEntities(theNewSpecId, theNewRevId);

                await context.Specification.AddAsync(aSpecModel.ToEntity(theNewSpecId, theNewRevId));
                await context.SpecSubLevel.AddRangeAsync(theSubLevelEntities);

                foreach (var subLevel in aSpecModel.SubLevels)
                {
                    await context.AddRangeAsync(subLevel.Choices.ToEntities(theNewSpecId, theNewRevId, subLevel.LevelSeq));
                }

                await context.SaveChangesAsync();

                //Default choice in the subLevel has to be null when saving the data for the first time to prevent an issue with circular dependency.  They must be updated after the first save.
                foreach (var subLevel in theSubLevelEntities)
                {
                    subLevel.DefaultChoice = aSpecModel.SubLevels.FirstOrDefault(i => i.LevelSeq == subLevel.SubLevelSeqId).DefaultChoice;
                }

                context.UpdateRange(theSubLevelEntities);

                await context.SaveChangesAsync();

                await transaction.CommitAsync();

                return theNewSpecId;
            }
        }

        public async Task<int> RevUpSpec(SpecModel aSpecModel)
        {
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                var newSpecRevId = await context.Specification.Where(i => i.SpecId == aSpecModel.Id).MaxAsync(i => i.SpecRevId);
                if (newSpecRevId == 0) { throw new Exception("Could not find previous spec to rev-up."); }
                newSpecRevId += 1;

                var theSpecEntity = aSpecModel.ToEntity(aSpecModel.Id, newSpecRevId);
                var theSubLevelEntities = aSpecModel.SubLevels.ToEntities(aSpecModel.Id, newSpecRevId);

                await context.Specification.AddAsync(theSpecEntity);
                await context.SpecSubLevel.AddRangeAsync(theSubLevelEntities);

                foreach (var subLevel in aSpecModel.SubLevels)
                {
                    await context.AddRangeAsync(subLevel.Choices.ToEntities(aSpecModel.Id, newSpecRevId, subLevel.LevelSeq));
                }

                await context.SaveChangesAsync();

                //Default choice in the subLevel has to be null when saving the data for the first time to prevent an issue with circular dependency.  They must be updated after the first save.
                foreach (var subLevel in theSubLevelEntities)
                {
                    subLevel.DefaultChoice = aSpecModel.SubLevels.FirstOrDefault(i => i.LevelSeq == subLevel.SubLevelSeqId).DefaultChoice;
                }

                context.UpdateRange(theSubLevelEntities);

                await context.SaveChangesAsync();

                await transaction.CommitAsync();

                return aSpecModel.Id;
            }
        }


    }
}
