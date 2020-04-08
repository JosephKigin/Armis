using Armis.BusinessModels.PartModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.PartExtensions
{
    public static class HardnessExtension
    {
        public static HardnessModel ToModel(this Hardness aHardnessEntity)
        {
            return new HardnessModel()
            {
                HardnessId = aHardnessEntity.HardnessId,
                ShortName = aHardnessEntity.ShortName,
                Description = aHardnessEntity.Description,
                HardnessMin = aHardnessEntity.HardnessMin,
                HardnessMax = aHardnessEntity.HardnessMax
            };
        }
    }
}
