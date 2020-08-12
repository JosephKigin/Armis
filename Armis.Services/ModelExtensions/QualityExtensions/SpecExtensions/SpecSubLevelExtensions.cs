using Armis.BusinessModels.QualityModels.Spec;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.QualityExtensions.SpecExtensions
{
    public static class SpecSubLevelExtensions
    {
        public static SpecSubLevelModel ToModel(this SpecSubLevel aSpecSubLevel)
        {
            return new SpecSubLevelModel()
            {
                Name = aSpecSubLevel.Name,
                IsRequired = aSpecSubLevel.IsRequired,
                LevelSeq = aSpecSubLevel.SubLevelSeqId,
                DefaultChoice = aSpecSubLevel.DefaultChoice
            };
        }

        public static SpecSubLevelModel ToHydratedModel(this SpecSubLevel aSpecSubLevel)
        {
            return new SpecSubLevelModel()
            {
                Name = aSpecSubLevel.Name,
                IsRequired = aSpecSubLevel.IsRequired,
                LevelSeq = aSpecSubLevel.SubLevelSeqId,
                DefaultChoice = aSpecSubLevel.DefaultChoice,

                Choices = aSpecSubLevel.SpecChoice.ToHydratedModels()
            };
        }

        public static IEnumerable<SpecSubLevelModel> ToHydratedModels(this IEnumerable<SpecSubLevel> aSpecSubLevelEntities)
        {
            var resultModels = new List<SpecSubLevelModel>();

            foreach (var subLevel in aSpecSubLevelEntities)
            {
                resultModels.Add(subLevel.ToHydratedModel());
            }

            return resultModels;
        }

        public static SpecSubLevel ToEntity(this SpecSubLevelModel aSpecSubLevelModel, int aSpecId, short aSpecRevId)
        {
            return new SpecSubLevel()
            {
                SpecId = aSpecId,
                SpecRevId = aSpecRevId,
                SubLevelSeqId = aSpecSubLevelModel.LevelSeq,
                Name = aSpecSubLevelModel.Name,
                IsRequired = aSpecSubLevelModel.IsRequired,
                DefaultChoice = null
            };
        }

        public static IEnumerable<SpecSubLevel> ToEntities(this IEnumerable<SpecSubLevelModel> aSpecSubLevelModels, int aSpecId, short aSpecRevId)
        {
            var resultEntities = new List<SpecSubLevel>();

            foreach (var specSubLevelModel in aSpecSubLevelModels)
            {
                resultEntities.Add(specSubLevelModel.ToEntity(aSpecId, aSpecRevId));
            }

            return resultEntities;
        }
    }
}
