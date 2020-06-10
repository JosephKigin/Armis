using Armis.BusinessModels.OrderEntryModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.OrderEntryExtensions
{
    public static class OrderShipToOverrideExtensions
    {
        public static OrderShipToOverrideModel ToModel(this OrderShipToOverride anOrderShipToOverrideEntity)
        {
            return new OrderShipToOverrideModel()
            {
                OrderId = anOrderShipToOverrideEntity.OrderId,
                Stattn = anOrderShipToOverrideEntity.Stattn,
                Stname = anOrderShipToOverrideEntity.Stname,
                Staddress1 = anOrderShipToOverrideEntity.Staddress1,
                Staddress2 = anOrderShipToOverrideEntity.Staddress2,
                Staddress3 = anOrderShipToOverrideEntity.Staddress3,
                Stcity = anOrderShipToOverrideEntity.Stcity,
                Ststate = anOrderShipToOverrideEntity.Ststate,
                Stzip = anOrderShipToOverrideEntity.Stzip,
                Stphone = anOrderShipToOverrideEntity.Stphone
            };
        }
    }
}
