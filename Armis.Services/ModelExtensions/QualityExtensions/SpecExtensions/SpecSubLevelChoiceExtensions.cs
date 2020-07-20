using Armis.BusinessModels.QualityModels.Spec;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.ModelExtensions.QualityExtensions.ProcessExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.QualityExtensions.SpecExtensions
{
    public static class SpecSubLevelChoiceExtensions
    {
        public static SpecSubLevelChoiceModel ToModel(this SpecChoice aSpecSubLevelChoice)
        {
            return new SpecSubLevelChoiceModel()
            {
                Description = aSpecSubLevelChoice.Description,
                ChoiceSeqId = aSpecSubLevelChoice.ChoiceSeqId,
                SubLevelSeqId = aSpecSubLevelChoice.SubLevelSeqId,
                ReferenceStepId = aSpecSubLevelChoice.ReferenceStepId,
                DependentSubLevelId = aSpecSubLevelChoice.DependentLevel,
                OnlyValidForChoiceId = aSpecSubLevelChoice.OnlyValidForChoice
            };
        }

        public static IEnumerable<SpecSubLevelChoiceModel> ToModels(this IEnumerable<SpecChoice> aSpecChoiceEntities)
        {
            var resultModels = new List<SpecSubLevelChoiceModel>();

            foreach (var entity in aSpecChoiceEntities)
            {
                resultModels.Add(entity.ToModel());
            }

            return resultModels;
        }

        public static SpecSubLevelChoiceModel ToHydratedModel(this SpecChoice aSpecChoiceEntity)
        {
            var result = aSpecChoiceEntity.ToModel();

            result.ReferenceStep = (result.ReferenceStep != null)? aSpecChoiceEntity.ReferenceStep.ToModel() : null;

            return result;
        }

        public static IEnumerable<SpecSubLevelChoiceModel> ToHydratedModels(this IEnumerable<SpecChoice> aSpecChoiceEntities)
        {
            var result = new List<SpecSubLevelChoiceModel>();

            foreach (var entity in aSpecChoiceEntities)
            {
                result.Add(entity.ToHydratedModel());
            }

            return result;
        }

        //There are a whole bunch of extra things this needs to know in order to get the entity built correctly.  TODO:Maybe this is something entity framework can take care of?
        public static SpecChoice ToEntity(this SpecSubLevelChoiceModel aChoiceModel, int aSpecId, short anInternalRevId)
        {
            return new SpecChoice()
            {
                SpecId = aSpecId,
                ChoiceSeqId = aChoiceModel.ChoiceSeqId,
                SpecRevId = anInternalRevId,
                Description = aChoiceModel.Description,
                SubLevelSeqId = aChoiceModel.SubLevelSeqId
            };
        }

        public static IEnumerable<SpecChoice> ToEntities(this IEnumerable<SpecSubLevelChoiceModel> aChoiceModelList, int aSpecId, short anInternalRevId)
        {
            var theEntities = new List<SpecChoice>();

            foreach (var specChoiceModel in aChoiceModelList)
            {
                theEntities.Add(specChoiceModel.ToEntity(aSpecId, anInternalRevId));
            }

            return theEntities;
        }
    }
}
