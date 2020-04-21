using Armis.BusinessModels.PartModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.PartExtensions
{
    public static class MaterialAlloyExtensions
    {
        public static MaterialAlloyModel ToModel(this MaterialAlloy anAlloyEntyity)
        {
            return new MaterialAlloyModel()
            {
                AlloyId = anAlloyEntyity.AlloyId,
                Description = anAlloyEntyity.Description,
                SeriesId = anAlloyEntyity.SeriesId ?? 0
            };
        }

        public static IEnumerable<MaterialAlloyModel> ToModels(this IEnumerable<MaterialAlloy> aMaterialAlloys)
        {
            var resultingModels = new List<MaterialAlloyModel>();

            foreach (var materialAlloyEntity in aMaterialAlloys)
            {
                resultingModels.Add(materialAlloyEntity.ToModel());
            }

            return resultingModels; 
        }
    }
}
