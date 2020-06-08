using Armis.BusinessModels.OrderEntryModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.OrderEntryExtensions
{
    public static class OrderHeadExtensions
    {
        public static OrderHeadModel ToModel(this OrderHead anOrderHeadEntity)
        {
            return new OrderHeadModel()
            {
                OrderId = anOrderHeadEntity.OrderId,
                CustId = anOrderHeadEntity.CustId,
                Ponum = anOrderHeadEntity.Ponum,
                OrderDate = anOrderHeadEntity.OrderDate,
                DueDate = anOrderHeadEntity.DueDate,
                ShipDate = anOrderHeadEntity.ShipDate,
                ShipTime = anOrderHeadEntity.ShipTime,
                ReqDate = anOrderHeadEntity.ReqDate,
                DoneDate = anOrderHeadEntity.DoneDate,
                DoneTime = anOrderHeadEntity.DoneTime,
                TargetDate = anOrderHeadEntity.TargetDate,
                PriceStatusId = anOrderHeadEntity.PriceStatusId,
                IsPriceHold = anOrderHeadEntity.IsPriceHold,
                IsBadJob = anOrderHeadEntity.IsBadJob,
                IsJobHold = anOrderHeadEntity.IsJobHold,
                JobHoldToEmp = anOrderHeadEntity.JobHoldToEmp 
            };
        }
    }
}
