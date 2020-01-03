using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ProcessExtensions
{
    public static class VariableExtensions
    {
        public static VariableModel ToModel(this StepVariable aVariable)
        {
            var result = new VariableModel();


            result.Template = aVariable.VarTempCdNavigation.ToModel();
            if (aVariable.DefaultMin != null) { result.Min = aVariable.DefaultMin; }
            if (aVariable.DefaultMax != null) { result.Max = aVariable.DefaultMax; }
            if(aVariable.UomcdNavigation != null) { result.UnitOfMeasure = aVariable.UomcdNavigation.ToModel(); }

            return result;
        }
    }
}
