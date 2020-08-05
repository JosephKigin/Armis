using Armis.BusinessModels.QualityModels.Process;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.QualityExtensions.ProcessExtensions
{
    public static class ProcessRevisionExtension
    {
        public static ProcessRevisionModel ToModel(this ProcessRevision aProcessRev, string aProcessName = "") 
        {
            return new ProcessRevisionModel()
            {
                CreatedByEmp = aProcessRev.CreatedByEmp,
                DateTimeCreated = aProcessRev.DateCreated.Add(aProcessRev.TimeCreated),
                Comments = aProcessRev.Comments,
                ProcessId = aProcessRev.ProcessId,
                ProcessRevId = aProcessRev.ProcessRevId,
                RevStatusId = aProcessRev.RevStatusId,
                ProcessName = aProcessName
            };
        }

        public static ProcessRevisionModel ToHydratedModel(this ProcessRevision aRev)
        {
            var theRevModel = aRev.ToModel();
            var theStepSeqModels = new List<StepSeqModel>();

            foreach (var stepSeq in aRev.ProcessStepSeq)
            {
                var theStepSeq = stepSeq.ToModel(stepSeq.Step.ToModel(), stepSeq.Operation.ToModel());
                theStepSeqModels.Add(theStepSeq);
            }

            theRevModel.StepSeqs = theStepSeqModels;

            return theRevModel;
        }

        public static ProcessRevision ToEntity(this ProcessRevisionModel aProcessRevModel)
        {
            return new ProcessRevision()
            {
                Comments = aProcessRevModel.Comments,
                CreatedByEmp = aProcessRevModel.CreatedByEmp,
                DateCreated = aProcessRevModel.DateTimeCreated.Date,
                ProcessId = aProcessRevModel.ProcessId,
                ProcessRevId = aProcessRevModel.ProcessRevId,
                RevStatusId = aProcessRevModel.RevStatusId,
                TimeCreated = aProcessRevModel.DateTimeCreated.TimeOfDay
            };
        }

        public static ProcessRevision ToHydratedEntity(this ProcessRevisionModel aProcessRevisionModel, List<ProcessStepSeq> aStepSeq)
        {
            return new ProcessRevision()
            {
                ProcessId = aProcessRevisionModel.ProcessId,
                ProcessRevId = aProcessRevisionModel.ProcessRevId,
                CreatedByEmp = aProcessRevisionModel.CreatedByEmp,
                DateCreated = aProcessRevisionModel.DateTimeCreated.Date,
                TimeCreated = aProcessRevisionModel.DateTimeCreated.TimeOfDay,
                RevStatusId = aProcessRevisionModel.RevStatusId,
                Comments = aProcessRevisionModel.Comments,
                ProcessStepSeq = aStepSeq
            };
        }
    }
}
