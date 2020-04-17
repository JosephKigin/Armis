using Armis.BusinessModels.QualityModels.Process;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.QualityExtensions.ProcessExtensions
{
    public static class StepSeqExtension
    {
        //To Model
        public static StepSeqModel ToModel(this ProcessStepSeq aStepSeq, StepModel aStep, OperationModel anOperation) //TODO: unsure if these should default to null or not or not be there at all.
        {
            return new StepSeqModel()
            {
                ProcessId = aStepSeq.ProcessId,
                RevisionId = aStepSeq.ProcessRevId,
                StepId = aStepSeq.StepId,
                Sequence = aStepSeq.StepSeq,
                OperationId = aStepSeq.OperationId,
                Step = aStep,
                Operation = anOperation
            };
        }

        //To Entity
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
