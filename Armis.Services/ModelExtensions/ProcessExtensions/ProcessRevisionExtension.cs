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
    }
}
