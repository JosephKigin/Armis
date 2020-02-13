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
        public static ProcessRevisionModel ToHydratedModel(this ProcessRevision aProcessRev, IEnumerable<StepModel> aSteps)
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
                Steps = aSteps
            };
        }

        public static ProcessRevisionModel ToHydratedModel(this ProcessRevision aRev)
        {
            var theRev = aRev.ToModel();
            var theSteps = new List<StepModel>();

            foreach (var aStep in aRev.ProcessStepSeq)
            {
                var theStep = aStep.Step.ToModel(aStep.StepSeq, aStep.Operation.ToModel());
                theSteps.Add(theStep);
            }

            theRev.Steps = theSteps;

            return theRev;
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
