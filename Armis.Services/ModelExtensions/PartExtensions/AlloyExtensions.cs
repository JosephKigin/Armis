using Armis.BusinessModels.PartModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.PartExtensions
{
    public static class AlloyExtensions
    {
        public static AlloyModel ToModel(this MaterialAlloy anAlloyEntyity)
        {
            return new AlloyModel()
            {
                AlloyId = anAlloyEntyity.AlloyId,
                Description = anAlloyEntyity.Description,
                SeriesId = anAlloyEntyity.SeriesId ?? 0
            };
        }
    }
}
