using Armis.BusinessModels.ShippingModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ShippingExtensions
{
    public static class ShipViaCodeExtensions
    {
        public static ShipViaCodeModel ToModel(this ShipViaCode aShipViaEntity)
        {
            return new ShipViaCodeModel()
            {
                ShipViaId = aShipViaEntity.ShipViaId,
                ShipViaTypeId = aShipViaEntity.ShipViaTypeId,
                Description = aShipViaEntity.Description,
                Code = aShipViaEntity.Code,
                CarrierId = aShipViaEntity.CarrierId
            };
        }

        public static IEnumerable<ShipViaCodeModel> ToModels(this IEnumerable<ShipViaCode> aShipViaEntities)
        {
            var result = new List<ShipViaCodeModel>();

            foreach (var entity in aShipViaEntities)
            {
                result.Add(entity.ToModel());
            }

            return result;
        }

        public static ShipViaCodeModel ToHydratedModel(this ShipViaCode aShipViaEntity)
        {
            var result = aShipViaEntity.ToModel();
            result.CarrierCode = aShipViaEntity.Carrier.ToModel();

            return result;
        }

        public static IEnumerable<ShipViaCodeModel> ToHydratedModels(this IEnumerable<ShipViaCode> aShipViaEntities)
        {
            var result = new List<ShipViaCodeModel>();

            foreach (var entity in aShipViaEntities)
            {
                result.Add(entity.ToHydratedModel());
            }

            return result;
        }
    }
}
