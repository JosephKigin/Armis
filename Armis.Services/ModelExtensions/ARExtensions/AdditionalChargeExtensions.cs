using Armis.BusinessModels.ARModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ARExtensions
{
    public static class AdditionalChargeExtensions
    {
        public static AdditionalChargeModel ToModel(this AddlCharge anAdditionalChargeEntity)
        {
            return new AdditionalChargeModel()
            {
                ChargeId = anAdditionalChargeEntity.ChargeId,
                Code = anAdditionalChargeEntity.Code,
                ChargeTypeId = anAdditionalChargeEntity.ChargeTypeId,
                DefaultAmount = anAdditionalChargeEntity.DefaultAmount
            };
        }

        public static IEnumerable<AdditionalChargeModel> ToModels(this IEnumerable<AddlCharge> anAdditionalChargeEntities)
        {
            var result = new List<AdditionalChargeModel>();

            foreach (var entity in anAdditionalChargeEntities)
            {
                result.Add(entity.ToModel());
            }

            return result;
        }

        public static AdditionalChargeModel ToHydratedModel(this AddlCharge anAdditionalChargeEntity)
        {
            var result = anAdditionalChargeEntity.ToModel();
            result.ChargeType = anAdditionalChargeEntity.ChargeType.ToModel();

            return result;
        }
    }
}
