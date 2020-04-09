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
                                            .Include(i => i.SpecificationRevision)
                                                .ThenInclude(i => i.SpecSubLevel)
                                                    .ThenInclude(i => i.SpecChoice)
                                                        .ToListAsync();

            if (entities == null || !entities.Any()) { throw new Exception("No Specs were returned."); }

            return entities.ToHydratedModels();
        }

        public async Task<IEnumerable<SpecModel>> GetAllSpecsWithCurrentRev()
        {
            var theSpecEntities = await context.Specification.Include(i => i.SpecificationRevision).ToListAsync();

            if (theSpecEntities == null || !theSpecEntities.Any()) { throw new Exception("No specifications were returned."); }

            foreach (var specEntity in theSpecEntities)
            {
                foreach (var revEntity in specEntity.SpecificationRevision)
                {
                    if (revEntity != specEntity.SpecificationRevision.OrderByDescending(i => i.SpecRevId).FirstOrDefault())
                    {
                        specEntity.SpecificationRevision.Remove(revEntity);
                    }
                }

            }

            return theSpecEntities.ToHydratedModels();
        }
        
        public async Task<IEnumerable<SpecModel>> GetAllHydratedSpecsWithOnlyCurrentRev()
        {
            var theSpecEntities = await context.Specification.Include(i => i.SpecificationRevision)
                                                                .ThenInclude(i => i.SpecSubLevel)
                                                                    .ThenInclude(i => i.SpecChoice).ToListAsync();

            if (theSpecEntities == null || !theSpecEntities.Any()) { throw new Exception("No specifications were returned."); }

            foreach (var specEntity in theSpecEntities)
            {
                foreach (var revEntity in specEntity.SpecificationRevision)
                {
                    if(revEntity != specEntity.SpecificationRevision.OrderByDescending(i => i.SpecRevId).FirstOrDefault())
                    {
                        specEntity.SpecificationRevision.Remove(revEntity);
                    }
                }
                
            }

            return theSpecEntities.ToHydratedModels();
        }

        public async Task<IEnumerable<SpecSubLevelModel>> GetSpecSubLevels(int aSpecId, short aSpecRevId)
        {
            var entities = await context.SpecSubLevel.Where(i => i.SpecId == aSpecId && i.SpecRevId == aSpecRevId)
                                                        .Include(i => i.SpecChoice)
                                                        .ToListAsync();

            if (entities == null || !entities.Any()) { return null; }

            return entities.ToHydratedModels();
        }

        public async Task<SpecModel> GetHydratedCurrentRevForSpec(int aSpecId)
        {
            var specEntity = await context.Specification.FirstOrDefaultAsync(i => i.SpecId == aSpecId);
            specEntity.SpecificationRevision.Add(await context.SpecificationRevision.Where(i => i.SpecId == aSpecId)
                                                                                        .Include(i => i.SpecSubLevel)
                                                                                            .ThenInclude(i => i.SpecChoice)
                                                                                                .OrderByDescending(i => i.SpecRevId).FirstOrDefaultAsync());

            if (specEntity == null) { return null; }

            return specEntity.ToHydratedModel();
        }

        public async Task<int> CreateNewSpec(SpecModel aSpecModel)
        {
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                var theNewSpecId = await context.Specification.MaxAsync(i => i.SpecId) + 1;
                short theNewRevId = 10; //All new specs start with a revId of 10
                if(aSpecModel.SpecRevModels.Count() > 1) { throw new Exception("Cannot save a new Specification with multiple revisions; only one revision is allowed."); }
                var theSpecRevModel = aSpecModel.SpecRevModels.FirstOrDefault(); //Only ONE revision can be passed in.
                var theSubLevelEntities = theSpecRevModel.SubLevels.ToEntities(theNewSpecId, theNewRevId);

                await context.Specification.AddAsync(aSpecModel.ToEntity(theNewSpecId));
                await context.SpecificationRevision.AddAsync(theSpecRevModel.ToEntity(theNewSpecId, theNewRevId));
                await context.SpecSubLevel.AddRangeAsync(theSubLevelEntities);

                foreach (var subLevel in theSpecRevModel.SubLevels)
                {
                    await context.AddRangeAsync(subLevel.Choices.ToEntities(theNewSpecId, theNewRevId, subLevel.LevelSeq));
                }

                await context.SaveChangesAsync();

                //Default choice in the subLevel has to be null when saving the data for the first time to prevent an issue with circular dependency.  They must be updated after the first save.
                foreach (var subLevel in theSubLevelEntities)
                {
                    var theDefualtChoice = theSpecRevModel.SubLevels.FirstOrDefault(i => i.LevelSeq == subLevel.SubLevelSeqId).DefaultChoice;
                    subLevel.DefaultChoice = (theDefualtChoice != 0)? theDefualtChoice : null; //If there isn't a default choice, it will get sent in as 0.  On the database side, it needs to be null.
                }

                context.UpdateRange(theSubLevelEntities);

                await context.SaveChangesAsync();

                await transaction.CommitAsync();

                return theNewSpecId;
            }
        }

        public async Task<int> RevUpSpec(SpecRevModel aSpecRevModel)
        {
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                var newSpecRevId = await context.SpecificationRevision.Where(i => i.SpecId == aSpecRevModel.SpecId).MaxAsync(i => i.SpecRevId);
                if (newSpecRevId == 0) { throw new Exception("Could not find previous revision to rev-up from."); }
                newSpecRevId += 1;

                var theSpecRevEntity = aSpecRevModel.ToEntity(aSpecRevModel.SpecId, newSpecRevId);
                var theSubLevelEntities = aSpecRevModel.SubLevels.ToEntities(aSpecRevModel.SpecId, newSpecRevId);

                await context.SpecificationRevision.AddAsync(theSpecRevEntity);
                await context.SpecSubLevel.AddRangeAsync(theSubLevelEntities);

                foreach (var subLevel in aSpecRevModel.SubLevels)
                {
                    await context.AddRangeAsync(subLevel.Choices.ToEntities(aSpecRevModel.SpecId, newSpecRevId, subLevel.LevelSeq));
                }

                await context.SaveChangesAsync();

                //Default choice in the subLevel has to be null when saving the data for the first time to prevent an issue with circular dependency.  They must be updated after the first save.
                foreach (var subLevel in theSubLevelEntities)
                {
                    subLevel.DefaultChoice = aSpecRevModel.SubLevels.FirstOrDefault(i => i.LevelSeq == subLevel.SubLevelSeqId).DefaultChoice;
                }

                context.UpdateRange(theSubLevelEntities);

                await context.SaveChangesAsync();

                await transaction.CommitAsync();

                return aSpecRevModel.SpecId;
            }
        }
    }
}