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

        /// <summary>
        /// Turns a Process Step Sequence entity into a basic model
        /// </summary>
        /// <param name="aStepSeq">Entity</param>
        /// <param name="aStep">Model</param>
        /// <param name="anOperation">Model</param>
        /// <returns>Basic Step Sequence Model</returns>
        public static StepSeqModel ToModel(this ProcessStepSeq aStepSeq) 
        {
            return new StepSeqModel()
            {
                ProcessId = aStepSeq.ProcessId,
                RevisionId = aStepSeq.ProcessRevId,
                StepId = aStepSeq.StepId,
                Sequence = aStepSeq.StepSeq,
                OperationId = aStepSeq.OperationId,
                Step = aStepSeq.Step.ToModel(),
                Operation = aStepSeq.Operation.ToModel()
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
