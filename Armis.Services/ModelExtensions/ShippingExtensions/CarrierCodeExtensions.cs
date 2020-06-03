using Armis.BusinessModels.ShippingModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ShippingExtensions
{
    public static class CarrierCodeExtensions
    {
        public static CarrierCodeModel ToModel(this CarrierCode aCarrierCodeEntity)
        {
            return new CarrierCodeModel()
            {
                CarrierId = aCarrierCodeEntity.CarrierId,
                Code = aCarrierCodeEntity.Code,
                Name = aCarrierCodeEntity.Name,
                Type = aCarrierCodeEntity.Type,
                OurAcctNum = aCarrierCodeEntity.OurAcctNum
            };
        }

        public static IEnumerable<CarrierCodeModel> ToModels(this IEnumerable<CarrierCode> aCarrierCodeEntities)
        {
            var result = new List<CarrierCodeModel>();

            foreach (var entity in aCarrierCodeEntities)
            {
                result.Add(entity.ToModel());
            }

            return result;
        }
    }
}
