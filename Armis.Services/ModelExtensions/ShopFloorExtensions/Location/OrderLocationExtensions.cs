using Armis.BusinessModels.ShopFloorModels.Location;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.ModelExtensions.ShippingExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ShopFloorExtensions.Location
{
    public static class OrderLocationExtensions
    {
        public static OrderLocationModel ToModel(this OrderLocation anOrderLocationEntity)
        {
            return new OrderLocationModel()
            {
                OrderId = anOrderLocationEntity.OrderId,
                OrderLine = anOrderLocationEntity.OrderLine,
                LocationId = anOrderLocationEntity.LocationId,
                ContainerId = anOrderLocationEntity.ContainerId
            };
        }

        public static OrderLocationModel ToHydratedModel(this OrderLocation anOrderLocationEntity)
        {
            var result = anOrderLocationEntity.ToModel();

            result.Container = anOrderLocationEntity.Container.ToModel();
            result.ShopLocation = anOrderLocationEntity.Location.ToModel();

            return result;
        }

        public static IEnumerable<OrderLocationModel> ToHydratedModels(this IEnumerable<OrderLocation> anOrderLocationEntity)
        {
            var result = new List<OrderLocationModel>();

            foreach (var entity in anOrderLocationEntity)
            {
                result.Add(entity.ToHydratedModel());
            }

            return result;
        }
    }
}
