using Armis.BusinessModels.OrderEntryModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.OrderEntryExtensions
{
    public static class OrderDetailExtensions
    {
        public static OrderDetailModel ToModel(this OrderDetail anOrderDetailEntity)
        {
            return new OrderDetailModel()
            {
                OrderId = anOrderDetailEntity.OrderId,
                OrderLine = anOrderDetailEntity.OrderLine,
                Quantity = anOrderDetailEntity.Quantity,
                PartId = anOrderDetailEntity.PartId,
                PartRevId = anOrderDetailEntity.PartRevId,
                Poprice = anOrderDetailEntity.Poprice,
                CalcPrice = anOrderDetailEntity.CalcPrice,
                AssignPrice = anOrderDetailEntity.AssignPrice,
                PriceCodeId = anOrderDetailEntity.PriceCodeId,
                LotCharge = anOrderDetailEntity.LotCharge
            };
        }
        public static IEnumerable<OrderDetailModel> ToModels(this IEnumerable<OrderDetail> anOrderDetailEntities)
        {
            var result = new List<OrderDetailModel>();

            foreach (var entity in anOrderDetailEntities)
            {
                result.Add(entity.ToModel());
            }

            return result;
        }
    }
}
