using Armis.BusinessModels.ARModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ARExtensions
{
    public static class AdditionalChargeTypeExtensions
    {
        public static AdditionalChargeTypeModel ToModel(this AddlChargeType anAdditionalChargeTypeEntity)
        {
            return new AdditionalChargeTypeModel()
            {
                ChargeTypeId = anAdditionalChargeTypeEntity.ChargeTypeId,
                Code = anAdditionalChargeTypeEntity.Code,
                Description = anAdditionalChargeTypeEntity.Description
            };
        }
    }
}
