using Armis.BusinessModels.ARModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ARExtensions
{
    public static class PriceStatusCodeExtensions
    {
        public static PriceStatusCodeModel ToModel(this PriceStatusCode aPriceStatusCodeModel)
        {
            return new PriceStatusCodeModel()
            {
                Code = aPriceStatusCodeModel.Code,
                PriceStatusId = aPriceStatusCodeModel.PriceStatusId
            };
        }
    }
}
