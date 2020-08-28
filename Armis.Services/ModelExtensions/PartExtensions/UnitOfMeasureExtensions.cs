using Armis.BusinessModels.PartModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.PartExtensions
{
    public static class UnitOfMeasureExtensions
    {
        public static UnitOfMeasureModel ToModel(this UnitOfMeasure aUoMEntity)
        {
            return new UnitOfMeasureModel()
            {
                UoMid = aUoMEntity.UoMid,
                Description = aUoMEntity.Description,
                Label = aUoMEntity.Label
            };
        }

        public static IEnumerable<UnitOfMeasureModel> ToModels(this IEnumerable<UnitOfMeasure> aUoMEntities)
        {
            var result = new List<UnitOfMeasureModel>();

            foreach (var entity in aUoMEntities)
            {
                result.Add(entity.ToModel());
            }

            return result;
        }
    }
}
