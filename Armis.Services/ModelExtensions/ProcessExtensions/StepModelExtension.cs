using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ProcessExtensions
{
    public static class StepModelExtension
    {
        public static StepModel ToModel(this Step aStep, int aSeq = 0, OperationModel anOperation = null)
        {
            var result = new StepModel()
            {
                Instructions = aStep.Instructions,
                SignOffIsRequired = aStep.SignOffIsRequired,
                StepCategoryCd = aStep.StepCategoryCd,
                StepId = aStep.StepId,
                StepName = aStep.StepName,
                Sequence = aSeq,
                Operation = anOperation
            };

            return result;
        }

        public static StepModel ToHydratedModel(this Step aStep, int aSeq = 0, OperationModel anOperation = null)
        {
            var result = new StepModel()
            {
                Instructions = aStep.Instructions,
                SignOffIsRequired = aStep.SignOffIsRequired,
                StepCategoryCd = aStep.StepCategoryCd,
                StepId = aStep.StepId,
                StepName = aStep.StepName,
                Sequence = aSeq,
                Operation = anOperation
            };

            var variableList = new List<StepVariableModel>();

            foreach (var variableSeq in aStep.StepVarSeq)
            {
                variableList.Add(variableSeq.StepVariable.ToModel());
            }

            result.Variables = variableList;

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

        public static IEnumerable<Step> ToEntity(this IEnumerable<StepModel> aStepModels)
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
