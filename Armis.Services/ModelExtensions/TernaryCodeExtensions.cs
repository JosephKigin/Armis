using Armis.BusinessModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions
{
    public static class TernaryCodeExtensions
    {
        public static TernaryCodeModel ToModel(this TernaryCode aTernaryCodeEntity)
        {
            return new TernaryCodeModel() 
            {
                Code = aTernaryCodeEntity.Code,
                TernaryCodeId = aTernaryCodeEntity.TernaryCodeId
            };

        }
    }
}
