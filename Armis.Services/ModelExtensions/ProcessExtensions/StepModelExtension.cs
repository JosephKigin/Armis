﻿using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ProcessExtensions
{
    public static class StepModelExtension
    {
        public static StepModel ToModel(this Step aStep)
        {
            var result = new StepModel()
            {
                Instructions = aStep.Instructions,
                SignOffIsRequired = aStep.SignOffIsRequired,
                StepCategoryCd = aStep.StepCategoryCd,
                StepId = aStep.StepId,
                Inactive = aStep.Inactive,
                StepName = aStep.StepName
            };

            return result;
        }

        public static StepModel ToHydratedModel(this Step aStep)
        {
            var result = new StepModel()
            {
                Instructions = aStep.Instructions,
                SignOffIsRequired = aStep.SignOffIsRequired,
                StepCategoryCd = aStep.StepCategoryCd,
                StepId = aStep.StepId,
                StepName = aStep.StepName
            };

            return result;

        }

        public static Step ToEntity(this StepModel aStepModel)
        {
            return new Step()
            {
                Instructions = aStepModel.Instructions,
                SignOffIsRequired = aStepModel.SignOffIsRequired,
                StepCategoryCd = aStepModel.StepCategoryCd,
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
