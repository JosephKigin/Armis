using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ProcessExtensions
{
    public static class VariableTemplateExtension
    {
        public static VariableTemplateModel ToModel(this StepVarTemplate anEntity)
        {
            return new VariableTemplateModel()
            {
                Code = anEntity.VarTempCd,
                Name = anEntity.VarName,
                Type = anEntity.StepVarTypeCd
            };
        }

        public static StepVarTemplate ToEntity(this VariableTemplateModel aModel)
        {
            return new StepVarTemplate()
            {
                VarTempCd = aModel.Code,
                VarName = aModel.Name,
                StepVarTypeCd = aModel.Type
            };
        }
    }
}
