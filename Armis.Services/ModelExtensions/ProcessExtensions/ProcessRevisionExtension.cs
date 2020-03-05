using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ProcessExtensions
{
    public static class ProcessRevisionExtension
    {
        public static ProcessRevisionModel ToModel(this ProcessRevision aProcessRev)
        {
            return new ProcessRevisionModel()
            {
                CreatedByEmp = aProcessRev.CreatedByEmp,
                DateCreated = aProcessRev.DateCreated,
                DueDays = aProcessRev.DueDays,
                Comments = aProcessRev.Comments,
                ProcessId = aProcessRev.ProcessId,
                ProcessRevId = aProcessRev.ProcessRevId,
                RevStatusCd = aProcessRev.RevStatusCd,
                TimeCreated = aProcessRev.TimeCreated
            };
        }

        //TODO: Refactor everything that uses this to use the methods below
        public static ProcessRevisionModel ToHydratedModel(this ProcessRevision aProcessRev, IEnumerable<StepSeqModel> aStepSeqs)
        {
            return new ProcessRevisionModel()
            {
                CreatedByEmp = aProcessRev.CreatedByEmp,
                DateCreated = aProcessRev.DateCreated,
                DueDays = aProcessRev.DueDays,
                Comments = aProcessRev.Comments,
                ProcessId = aProcessRev.ProcessId,
                ProcessRevId = aProcessRev.ProcessRevId,
                RevStatusCd = aProcessRev.RevStatusCd,
                TimeCreated = aProcessRev.TimeCreated,
                StepSeqs = aStepSeqs
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
                DateCreated = aProcessRevModel.DateCreated,
                DueDays = aProcessRevModel.DueDays,
                ProcessId = aProcessRevModel.ProcessId,
                ProcessRevId = aProcessRevModel.ProcessRevId,
                RevStatusCd = aProcessRevModel.RevStatusCd,
                TimeCreated = aProcessRevModel.TimeCreated
            };
        }

        public static ProcessRevision ToHydratedEntity(this ProcessRevisionModel aProcessRevisionModel, List<ProcessStepSeq> aStepSeq)
        {
            return new ProcessRevision()
            {
                ProcessId = aProcessRevisionModel.ProcessId,
                ProcessRevId = aProcessRevisionModel.ProcessRevId,
                CreatedByEmp = aProcessRevisionModel.CreatedByEmp,
                DateCreated = aProcessRevisionModel.DateCreated,
                TimeCreated = aProcessRevisionModel.TimeCreated,
                RevStatusCd = aProcessRevisionModel.RevStatusCd,
                DueDays = aProcessRevisionModel.DueDays,
                Comments = aProcessRevisionModel.Comments,
                ProcessStepSeq = aStepSeq
            };
        }
    }
}
