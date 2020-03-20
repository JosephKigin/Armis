using Armis.BusinessModels.ProcessModels.Spec;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ProcessExtensions.SpecExtensions
{
    public static class SpecSubLevelExtensions
    {
        public static SpecSubLevelModel ToModel(this SpecSubLevel aSpecSubLevel)
        {
            return new SpecSubLevelModel()
            {
                SpecId = aSpecSubLevel.SpecId,
                InternalRev = aSpecSubLevel.SpecRevId,
                Name = aSpecSubLevel.Name,
                IsRequired = aSpecSubLevel.IsRequired,
                LevelSeq = aSpecSubLevel.SubLevelSeqId
            };
        }

        public static SpecSubLevelModel ToHydratedModel(this SpecSubLevel aSpecSubLevel)
        {
            var resultModel = aSpecSubLevel.ToModel();

            var choicesList = new List<SpecSubLevelChoiceModel>();
            foreach (var choice in aSpecSubLevel.SpecChoice)
            {
                choicesList.Add(choice.ToModel());
            }

            resultModel.Choices = choicesList;

            return resultModel;
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
    }
}
