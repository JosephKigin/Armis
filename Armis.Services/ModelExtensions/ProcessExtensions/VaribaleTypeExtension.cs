using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ProcessExtensions
{
    public static class VaribaleTypeExtension
    {
        public static VariableTypeModel ToModel(this StepVarType anEntity)
        {
            return new VariableTypeModel()
            {
                Code = anEntity.StepVarTypeCd,
                Description = anEntity.Description
            };
        }
    }
}
