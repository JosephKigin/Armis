using Armis.BusinessModels.ShopFloorModels.Location;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ShopFloorExtensions.LocationExtensions
{
    public static class ShopLocationExtensions
    {
        public static ShopLocationModel ToModel(this ShopLocation aShopLocation)
        {
            return new ShopLocationModel()
            {
                LocationId = aShopLocation.LocationId,
                LocCode = aShopLocation.LocCode,
                Description = aShopLocation.Description,
                AreaId = aShopLocation.AreaId,
                LocationTypeId = aShopLocation.LocationTypeId
            };
        }

        public static IEnumerable<ShopLocationModel> ToModels(this IEnumerable<ShopLocation> aShopLocations)
        {
            var result = new List<ShopLocationModel>();

            foreach (var entity in aShopLocations)
            {
                result.Add(entity.ToModel());
            }

            return result;
        }
    }
}
