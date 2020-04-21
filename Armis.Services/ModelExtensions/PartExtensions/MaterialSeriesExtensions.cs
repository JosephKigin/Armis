using Armis.BusinessModels.PartModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.PartExtensions
{
    public static class MaterialSeriesExtensions
    {
        public static MaterialSeriesModel ToModel(this MaterialSeries aSeriesEntity)
        {
            return new MaterialSeriesModel()
            {
                SeriesId = aSeriesEntity.SeriesId,
                Description = aSeriesEntity.Description,
                ShortName = aSeriesEntity.ShortName,
                Type = aSeriesEntity.Type
            };
        }

        public static IEnumerable<MaterialSeriesModel> ToModels(this IEnumerable<MaterialSeries> aSeriesEntities)
        {
            var resultingModels = new List<MaterialSeriesModel>();
            
            foreach (var series in aSeriesEntities)
            {
                resultingModels.Add(series.ToModel());
            }

            return resultingModels;
        }
    }
}
