using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ProcessExtensions
{
    public static class UOMExtensions
    {
        public static UOMCodeModel ToModel(this UOMcode anEntity)
        {
            return new UOMCodeModel()
            {
                Code = anEntity.Uomcd,
                Description = anEntity.Uomdesc
            };
        }
    }
}
