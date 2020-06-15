using Armis.BusinessModels.OrderEntryModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.OrderEntryExtensions
{
    public static class OrderDetailCommentsExtensions
    {
        public static OrderDetailCommentModel ToModel(this OrderDetailComment anOrderDetailCommentEntity)
        {
            return new OrderDetailCommentModel()
            {
                OrderId = anOrderDetailCommentEntity.OrderId,
                OrderLine = anOrderDetailCommentEntity.OrderLine,
                Comments1 = anOrderDetailCommentEntity.Comments1,
                Comments2 = anOrderDetailCommentEntity.Comments2,
                Comments3 = anOrderDetailCommentEntity.Comments3
            };
        }
    }
}
