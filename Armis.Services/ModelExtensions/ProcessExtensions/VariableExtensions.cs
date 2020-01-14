﻿using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ProcessExtensions
{
    public static class VariableExtensions
    {
        public static StepVariableModel ToModel(this StepVariable aVariable)
        {
            var result = new StepVariableModel();


            result.Template = aVariable.VarTempCdNavigation.ToModel();
            if (aVariable.DefaultMin != null) { result.Min = aVariable.DefaultMin; }
            if (aVariable.DefaultMax != null) { result.Max = aVariable.DefaultMax; }
            if(aVariable.UomcdNavigation != null) { result.UnitOfMeasure = aVariable.UomcdNavigation.ToModel(); }

            return result;
        }

        public static StepVariable ToEntity(this StepVariableModel aVariableModel)
        {
            var result = new StepVariable();

            result.VarTempCd = aVariableModel.Template.Code;
            if(aVariableModel.Min != null) { result.DefaultMin = aVariableModel.Min; }
            if(aVariableModel.Max != null) { result.DefaultMax = aVariableModel.Max; }
            if(aVariableModel.UnitOfMeasure != null) { result.Uomcd = aVariableModel.UnitOfMeasure.Code; }

            return result;
        }
    }
}