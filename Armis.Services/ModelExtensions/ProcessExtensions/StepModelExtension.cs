using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ProcessExtensions
{
    public static class StepModelExtension
    {
        public static StepModel ToModel(this Step step, SubOpStepSeq seq)
        {
            return new StepModel()
            {
                Instructions = step.Instructions,
                SignOffIsRequired = step.SignOffIsRequired,
                StepCategoryCd = step.StepCategoryCd,
                StepId = step.StepId,
                StepName = step.StepName,
                Sequence = seq.StepSeq
            };
        }
    }
}
