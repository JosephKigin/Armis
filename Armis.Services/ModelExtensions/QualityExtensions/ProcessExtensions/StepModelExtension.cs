using Armis.BusinessModels.QualityModels.Process;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.QualityExtensions.ProcessExtensions
{
    public static class StepModelExtension
    {
        public static StepModel ToModel(this Step aStep)
        {
            var result = new StepModel()
            {
                Instructions = aStep.Instructions,
                SignOffIsRequired = aStep.SignOffIsRequired,
                StepCategory = aStep.StepCategory.ToModel(),
                Inactive = aStep.Inactive,
                StepId = aStep.StepId,
                StepName = aStep.StepName
            };

            return result;

        }

        public static IEnumerable<StepModel> ToModels(this IEnumerable<Step> aStepEntities)
        {
            var result = new List<StepModel>();

            foreach (var stepEntity in aStepEntities)
            {
                result.Add(stepEntity.ToModel());
            }

            return result;
        }

        public static Step ToEntity(this StepModel aStepModel)
        {
            return new Step()
            {
                Instructions = aStepModel.Instructions,
                SignOffIsRequired = aStepModel.SignOffIsRequired,
                StepCategoryId = aStepModel.StepCategory.Id,
                StepId = aStepModel.StepId,
                StepName = aStepModel.StepName
            };
        }

        public static IEnumerable<Step> ToEntities(this IEnumerable<StepModel> aStepModels)
        {
            var theStepEntities = new List<Step>();
            foreach (var aStep in aStepModels)
            {
                theStepEntities.Add(aStep.ToEntity());
            }

            return theStepEntities;
        }
    }
}
