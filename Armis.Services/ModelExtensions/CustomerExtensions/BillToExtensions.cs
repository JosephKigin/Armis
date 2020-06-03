using Armis.BusinessModels.CustomerModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.CustomerExtensions
{
    public static class BillToExtensions
    {
        public static BillToModel ToModel(this CustBillTo aBillToEntity)
        {
            return new BillToModel()
            {
                CustId = aBillToEntity.CustId,
                Address1 = aBillToEntity.Address1,
                Address2 = aBillToEntity.Address2,
                Address3 = aBillToEntity.Address3,
                City = aBillToEntity.City,
                State = aBillToEntity.State,
                Zip = aBillToEntity.Zip,
                Country = aBillToEntity.Country,
                PhoneNum = aBillToEntity.PhoneNum,
                FaxNum = aBillToEntity.FaxNum
            };
        }

        public static IEnumerable<BillToModel> ToModels(this IEnumerable<CustBillTo> aBillToEntities)
        {
            var result = new List<BillToModel>();

            foreach (var entity in aBillToEntities)
            {
                result.Add(entity.ToModel());
            }

            return result;
        }
    }
}
