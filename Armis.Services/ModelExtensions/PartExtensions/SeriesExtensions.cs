using Armis.BusinessModels.PartModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.PartExtensions
{
    public static class SeriesExtensions
    {
        public static SeriesModel ToModel(this MaterialSeries aSeriesEntity)
        {
            return new SeriesModel()
            {
                SeriesId = aSeriesEntity.SeriesId,
                Description = aSeriesEntity.Description,
                ShortName = aSeriesEntity.ShortName,
                Type = aSeriesEntity.Type
            };
        }
    }
}
