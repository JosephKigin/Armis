﻿using Armis.BusinessModels.PartModels;
using Armis.Data.DatabaseContext.Entities;
using System.Collections.Generic;

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

        public static MaterialSeries ToEntity(this MaterialSeriesModel aMaterialSeriesModel)
        {
            return new MaterialSeries()
            {
                ShortName = aMaterialSeriesModel.ShortName,
                Description = aMaterialSeriesModel.Description,
                Type = aMaterialSeriesModel.Type
            };
        }
    }
}
