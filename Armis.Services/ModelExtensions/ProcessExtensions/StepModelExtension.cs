﻿using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ProcessExtensions
{
    public static class StepModelExtension
    {
        public static StepModel ToModel(this Step aStep, int aSeq)
        {
            return new StepModel()
            {
                Instructions = aStep.Instructions,
                SignOffIsRequired = aStep.SignOffIsRequired,
                StepCategoryCd = aStep.StepCategoryCd,
                StepId = aStep.StepId,
                StepName = aStep.StepName,
                Sequence = aSeq
            };
        }

        public static Step ToEntity(this StepModel aStepModel)
        {
            var theStep = new Step()
            {
                Instructions = aStepModel.Instructions,
                SignOffIsRequired = aStepModel.SignOffIsRequired,
                StepCategoryCd = aStepModel.StepCategoryCd,
                StepId = aStepModel.StepId,
                StepName = aStepModel.StepName
            };

            if (aStepModel.StepId != 0) { theStep.StepId = aStepModel.StepId; }

            return theStep;
        }
    }
}
