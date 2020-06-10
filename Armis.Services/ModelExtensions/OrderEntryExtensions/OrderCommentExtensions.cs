using Armis.BusinessModels.OrderEntryModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.OrderEntryExtensions
{
    public static class OrderCommentExtensions
    {
        public static OrderCommentModel ToModel(this OrderComment anOrderCommentEntity)
        {
            return new OrderCommentModel()
            {
                OrderId = anOrderCommentEntity.OrderId,
                OrderComments = anOrderCommentEntity.OrderComments,
                InternalComments = anOrderCommentEntity.InternalComments,
                Raicomments = anOrderCommentEntity.Raicomments,
                CredAuthComments = anOrderCommentEntity.CredAuthComments,
                VoidComments = anOrderCommentEntity.VoidComments,
                JobHoldComments = anOrderCommentEntity.JobHoldComments
            };
        }
    }
}
