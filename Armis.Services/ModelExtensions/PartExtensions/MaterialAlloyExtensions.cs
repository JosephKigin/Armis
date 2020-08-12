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
                MaterialAlloyId = anAlloyEntyity.MaterialAlloyId,
                Description = anAlloyEntyity.Description,
                MaterialSeriesId = anAlloyEntyity.MaterialSeriesId ?? 0
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

        public static MaterialAlloy ToEntity(this MaterialAlloyModel aMaterialAlloyModel)
        {
            return new MaterialAlloy()
            {
                 Description = aMaterialAlloyModel.Description,
                 MaterialSeriesId = aMaterialAlloyModel.MaterialSeriesId
            };
        }
    }
}
