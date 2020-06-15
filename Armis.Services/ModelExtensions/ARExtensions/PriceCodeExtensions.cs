using Armis.BusinessModels.ARModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ARExtensions
{
    public static class PriceCodeExtensions
    {
        public static PriceCodeModel ToModel(this PriceCode aPriceCodeEntity)
        {
            return new PriceCodeModel()
            {
                PriceCodeId = aPriceCodeEntity.PriceCodeId,
                LongCode = aPriceCodeEntity.LongCode,
                ShortCode = aPriceCodeEntity.ShortCode,
                Description = aPriceCodeEntity.Description
            };
        }

        public static IEnumerable<PriceCodeModel> ToModels(this IEnumerable<PriceCode> aPriceCodeEntities)
        {
            var result = new List<PriceCodeModel>();

            foreach (var entity in aPriceCodeEntities)
            {
                result.Add(entity.ToModel());
            }

            return result;
        }
    }
}
