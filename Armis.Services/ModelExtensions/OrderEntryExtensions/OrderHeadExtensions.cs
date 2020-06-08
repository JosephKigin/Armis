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
                
            };
        }
    }
}
