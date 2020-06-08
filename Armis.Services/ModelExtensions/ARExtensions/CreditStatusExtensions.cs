using Armis.BusinessModels.ARModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ARExtensions
{
    public static class CreditStatusExtensions
    {
        public static CreditStatusModel ToModel(this CreditStatus aCreditStatusEntity)
        {
            return new CreditStatusModel()
            {
                CredStatusId = aCreditStatusEntity.CredStatusId,
                Code = aCreditStatusEntity.Code,
                Description = aCreditStatusEntity.Description
            };
        }
    }
}
