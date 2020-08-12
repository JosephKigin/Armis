using Armis.BusinessModels.ShippingModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ShippingExtensions
{
    public static class OrderReceivedExtensions
    {
        public static OrderReceivedModel ToModel(this OrderReceived anOrderReceivedEntity)
        {
            return new OrderReceivedModel()
            {
                OrderId = anOrderReceivedEntity.OrderId,
                ReceivedNum = anOrderReceivedEntity.ReceivedNum,
                ReceivedContainerId = anOrderReceivedEntity.ReceivedContainerId,
                ReceivedContainerQty = anOrderReceivedEntity.ReceivedContainerQty,
                ReceivedDate = anOrderReceivedEntity.ReceivedDate,
                ReceivedTime = anOrderReceivedEntity.ReceivedTime
            };
        }

        public static IEnumerable<OrderReceivedModel> ToModels(this IEnumerable<OrderReceived> anOrderReceivedEntities)
        {
            var result = new List<OrderReceivedModel>();

            foreach (var entity in anOrderReceivedEntities)
            {
                result.Add(entity.ToModel());
            }

            return result;
        }

        public static OrderReceivedModel ToHydratedModel(this OrderReceived anOrderReceivedEntity)
        {
            var result = anOrderReceivedEntity.ToModel();
            result.ReceivedContainer = anOrderReceivedEntity.ReceivedContainer.ToModel();

            return result;
        }

        public static IEnumerable<OrderReceivedModel> ToHydratedModels(this IEnumerable<OrderReceived> anOrderReceivedEntities)
        {
            var result = new List<OrderReceivedModel>();

            foreach (var entity in anOrderReceivedEntities)
            {
                result.Add(entity.ToHydratedModel());
            }

            return result;
        }
    }
}
