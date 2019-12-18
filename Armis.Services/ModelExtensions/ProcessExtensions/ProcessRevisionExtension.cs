using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ProcessExtensions
{
    public static class ProcessRevisionExtension
    {
        public static ProcessRevisionModel ToModel(this ProcessRevision aProcessRev, IEnumerable<SubopRevisionModel> aSubOpRevModels, string aName)
        {
            return new ProcessRevisionModel()
            {
                ProcessName = aName,
                CreatedByEmp = aProcessRev.CreatedByEmp,
                DateCreated = aProcessRev.DateCreated,
                DueDays = aProcessRev.DueDays,
                Notes = aProcessRev.Notes,
                ProcessId = aProcessRev.ProcessId,
                ProcessRevId = aProcessRev.ProcessRevId,
                RevStatusCd = aProcessRev.RevStatusCd,
                TimeCreated = aProcessRev.TimeCreated,
                SubOpRevisions = aSubOpRevModels
            };
        }
    }
}
