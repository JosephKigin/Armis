using Armis.BusinessModels.ShippingModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ShippingExtensions
{
    public static class ShipToExtensions
    {
        public static ShipToModel ToModel(this ShipTo aShipToEntity)
        {
            return new ShipToModel()
            {
                CustId = aShipToEntity.CustId,
                ShipToId = aShipToEntity.ShipToId,
                Inactive = aShipToEntity.Inactive,
                Name = aShipToEntity.Name,
                Address1 = aShipToEntity.Address1,
                Address2 = aShipToEntity.Address2,
                Address3 = aShipToEntity.Address3,
                City = aShipToEntity.City,
                State = aShipToEntity.State,
                Zip = aShipToEntity.Zip,
                Country = aShipToEntity.Country,
                DefaultShipViaId = aShipToEntity.DefaultShipViaId,
                EmailAddress = aShipToEntity.EmailAddress,
                PhoneNum = aShipToEntity.PhoneNum,
                FaxNum = aShipToEntity.FaxNum
            };
        }

        public static IEnumerable<ShipToModel> ToModels(this IEnumerable<ShipTo> aShipToEntities)
        {
            var result = new List<ShipToModel>();

            foreach (var entity in aShipToEntities)
            {
                result.Add(entity.ToModel());
            }

            return result;
        }

        public static ShipToModel ToHydratedModel(this ShipTo aShipToEntity)
        {
            var result = aShipToEntity.ToModel();
            result.ShipViaCode = aShipToEntity.DefaultShipVia.ToHydratedModel();

            return result;
        }
    }
}
