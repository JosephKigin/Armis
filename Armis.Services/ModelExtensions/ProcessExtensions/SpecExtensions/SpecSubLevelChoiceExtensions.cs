using Armis.BusinessModels.ProcessModels.Spec;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ProcessExtensions.SpecExtensions
{
    public static class SpecSubLevelChoiceExtensions
    {
        public static SpecSubLevelChoiceModel ToModel(this SpecChoice aSpecSubLevelChoice)
        {
            return new SpecSubLevelChoiceModel()
            {
                Name = aSpecSubLevelChoice.Description,
                ChoiceSeq = aSpecSubLevelChoice.ChoiceSeqId
            };
        }

        //There are a whole bunch of extra things this needs to know in order to get the entity built correctly.  TODO:Maybe this is something entity framework can take care of?
        public static SpecChoice ToEntity(this SpecSubLevelChoiceModel aChoiceModel, int aSpecId, short anInternalRevId, byte aSubLevelSeqId)
        {
            return new SpecChoice()
            {
                SpecId = aSpecId,
                ChoiceSeqId = aChoiceModel.ChoiceSeq,
                SpecRevId = anInternalRevId,
                Description = aChoiceModel.Name,
                SubLevelSeqId = aSubLevelSeqId
            };
        }

        public static IEnumerable<SpecChoice> ToEntities(this IEnumerable<SpecSubLevelChoiceModel> aChoiceModelList, int aSpecId, short anInternalRevId, byte aSubLevelSeqId)
        {
            var theEntities = new List<SpecChoice>();

            foreach (var specChoiceModel in aChoiceModelList)
            {
                theEntities.Add(specChoiceModel.ToEntity(aSpecId, anInternalRevId, aSubLevelSeqId));
            }

            return theEntities;
        }
    }
}
