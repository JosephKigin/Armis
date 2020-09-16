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
                ReceivedTime = anOrderReceivedEntity.ReceivedTime,
                ReceivedTimeString = (new DateTime(anOrderReceivedEntity.ReceivedTime.Ticks)).ToString("h:mm tt")
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

        public static OrderReceived ToEntity(this OrderReceivedModel anOrderReceivedModel)
        {
            return new OrderReceived()
            {
                OrderId = anOrderReceivedModel.OrderId,
                ReceivedNum = anOrderReceivedModel.ReceivedNum,
                ReceivedContainerId = anOrderReceivedModel.ReceivedContainerId,
                ReceivedContainerQty = anOrderReceivedModel.ReceivedContainerQty,
                ReceivedDate = anOrderReceivedModel.ReceivedDate,
                ReceivedTime = TimeSpan.Parse(anOrderReceivedModel.ReceivedTimeString) //Timespans can not be passed using json, so the time must be passed in as a string and then converted into a TimeSpan
            };
        }
    }
}
