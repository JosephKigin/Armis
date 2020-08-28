using Armis.BusinessModels.OrderEntryModels;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.ModelExtensions.ARExtensions;
using Armis.DataLogic.ModelExtensions.PartExtensions;
using Armis.DataLogic.ModelExtensions.ShopFloorExtensions.LocationExtensions;
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
                PartRevId = anOrderDetailEntity.PartId,
                Poprice = anOrderDetailEntity.Poprice,
                CalcPrice = anOrderDetailEntity.CalcPrice,
                AssignPrice = anOrderDetailEntity.AssignPrice,
                PriceCodeId = anOrderDetailEntity.PriceCodeId,
                LotCharge = anOrderDetailEntity.LotCharge,
                Description = anOrderDetailEntity.Description
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

        public static OrderDetailModel ToHydratedModel(this OrderDetail anOrderDetailEntity)
        {
            var result = anOrderDetailEntity.ToModel();

            result.OrderLocation = (anOrderDetailEntity.OrderLocation != null) ? anOrderDetailEntity.OrderLocation.ToHydratedModels() : null;
            result.PriceCode = (anOrderDetailEntity.PriceCode != null) ? anOrderDetailEntity.PriceCode.ToModel() : null;
            result.OrderDetailComment = anOrderDetailEntity.OrderDetailComment?.ToModel();
            result.Part = (anOrderDetailEntity.Part != null) ? anOrderDetailEntity.Part.ToModel() : null;

            return result;
        }

        public static IEnumerable<OrderDetailModel> ToHydratedModels(this IEnumerable<OrderDetail> anOrderDetailEntities)
        {
            var result = new List<OrderDetailModel>();

            foreach (var entity in anOrderDetailEntities)
            {
                result.Add(entity.ToHydratedModel());
            }

            return result;
        }

        public static OrderDetail ToEntity(this OrderDetailModel anOrderDetailModel)
        {
            return new OrderDetail()
            {
                OrderId = anOrderDetailModel.OrderId,
                OrderLine = anOrderDetailModel.OrderLine,
                Quantity = anOrderDetailModel.Quantity,
                PartId = anOrderDetailModel.PartId,
                Poprice = anOrderDetailModel.Poprice,
                CalcPrice = anOrderDetailModel.CalcPrice,
                AssignPrice = anOrderDetailModel.AssignPrice,
                PriceCodeId = anOrderDetailModel.PriceCodeId,
                LotCharge = anOrderDetailModel.LotCharge
            };
        }

        public static IEnumerable<OrderDetail> ToEntities(this IEnumerable<OrderDetailModel> anOrderDetailModels)
        {
            var result = new List<OrderDetail>();

            foreach (var model in anOrderDetailModels)
            {
                result.Add(model.ToEntity());
            }

            return result;
        }
    }
}