using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ProcessExtensions
{
    public static class StepSeqExtension
    {
         public static ProcessStepSeq ToEntity(this StepSeqModel aStepSeqModel)
        {
            return new ProcessStepSeq()
            {
                OperationId = aStepSeqModel.OperationId,
                ProcessId = aStepSeqModel.ProcessId,
                ProcessRevId = aStepSeqModel.RevisionId,
                StepId = aStepSeqModel.StepId,
                StepSeq = aStepSeqModel.Sequence
            };
        }

        public static IEnumerable<ProcessStepSeq> ToEntities(this IEnumerable<StepSeqModel> aStepSeqModels)
        {
            var theStepSeqEntities = new List<ProcessStepSeq>();

            foreach (var aStepSeqModel in aStepSeqModels)
            {
                theStepSeqEntities.Add(aStepSeqModel.ToEntity());
            }

            return theStepSeqEntities;
        }
    }
}
