using Armis.BusinessModels.OrderEntryModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.OrderEntryExtensions
{
    public static class OrderExpediteExtensions
    {
        public static OrderExpediteModel ToModel(this OrderExpedite anOrderExpediteEntity)
        {
            return new OrderExpediteModel()
            {
                OrderId = anOrderExpediteEntity.OrderId,
                IsFree = anOrderExpediteEntity.IsFree,
                IsOnTime = anOrderExpediteEntity.IsOnTime,
                IsEmailOnly = anOrderExpediteEntity.IsEmailOnly,
                FeeAmount = anOrderExpediteEntity.FeeAmount,
                ExpeditedByEmp = anOrderExpediteEntity.ExpeditedByEmp,
                ExpeditedDate = anOrderExpediteEntity.ExpeditedDate,
                ReworkOrder = anOrderExpediteEntity.ReworkOrder,
                DepartmentId = anOrderExpediteEntity.DepartmentId
            };
        }
    }
}
