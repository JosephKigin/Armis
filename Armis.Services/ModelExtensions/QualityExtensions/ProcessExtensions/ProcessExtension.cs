using Armis.BusinessModels.QualityModels.Process;
using Armis.Data.DatabaseContext.Entities;
using System.Collections.Generic;

namespace Armis.DataLogic.ModelExtensions.QualityExtensions.ProcessExtensions
{
    public static class ProcessExtension
    {
        public static ProcessModel ToHydratedModel(this Process aProcess)
        {
            var theProcessModel = aProcess.ToModel();
            var theRevModels = new List<ProcessRevisionModel>();

            foreach (var rev in aProcess.ProcessRevision)
            {
                var theRevModel = rev.ToModel();
                var theStepSeqModels = new List<StepSeqModel>();

                foreach (var stepSeq in rev.ProcessStepSeq)
                {
                    var theStepSeqModel = stepSeq.ToModel(stepSeq.Step.ToModel(), stepSeq.Operation.ToModel());
                    theStepSeqModels.Add(theStepSeqModel);
                }

                theRevModel.StepSeqs = theStepSeqModels;
                theRevModels.Add(theRevModel);
            }

            theProcessModel.Revisions = theRevModels;

            return theProcessModel;
        }

        public static List<ProcessModel> ToHydratedModels(this List<Process> aProcesses)
        {
            var resultProcessModel = new List<ProcessModel>();

            foreach (var process in aProcesses)
            { 
                resultProcessModel.Add(process.ToHydratedModel());
            }

            return resultProcessModel;
        }

        public static ProcessModel ToModel(this Process aProcess)
        {
            return new ProcessModel()
            {
                Name = aProcess.Name,
                ProcessId = aProcess.ProcessId
            };
        }

        //To entity
        public static Process ToEntity(this ProcessModel aProcessModel)
        {
            return new Process()
            {
                Name = aProcessModel.Name
            };
        }
    }
}
