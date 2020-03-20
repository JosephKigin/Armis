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
                ChoiceSeq = aSpecSubLevelChoice.ChoiceSeqId,
                IsDefault = aSpecSubLevelChoice.IsDefault
            };
        }
    }
}
