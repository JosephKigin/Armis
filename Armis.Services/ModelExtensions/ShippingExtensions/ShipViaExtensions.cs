using Armis.BusinessModels.ShippingModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ShippingExtensions
{
    public static class ShipViaExtensions
    {
        public static ShipViaModel ToModel(this ShipViaCode aShipViaEntity)
        {
            return new ShipViaModel()
            {
                ShipViaId = aShipViaEntity.ShipViaId,
                ShipViaTypeId = aShipViaEntity.ShipViaTypeId,
                Description = aShipViaEntity.Description,
                Code = aShipViaEntity.Code,
                CarrierId = aShipViaEntity.CarrierId
            };
        }

        public static IEnumerable<ShipViaModel> ToModels(this IEnumerable<ShipViaCode> aShipViaEntities)
        {
            var result = new List<ShipViaModel>();

            foreach (var entity in aShipViaEntities)
            {
                result.Add(entity.ToModel());
            }

            return result;
        }

        public static ShipViaModel ToHydratedModel(this ShipViaCode aShipViaEntity)
        {
            var result = aShipViaEntity.ToModel();
            result.CarrierCodeModel = aShipViaEntity.Carrier.ToModel();

            return result;
        }

        public static IEnumerable<ShipViaModel> ToHydratedModels(this IEnumerable<ShipViaCode> aShipViaEntities)
        {
            var result = new List<ShipViaModel>();

            foreach (var entity in aShipViaEntities)
            {
                result.Add(entity.ToHydratedModel());
            }

            return result;
        }
    }
}
