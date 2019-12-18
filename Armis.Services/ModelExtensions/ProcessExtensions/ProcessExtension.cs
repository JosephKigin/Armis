using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ProcessExtensions
{
    public static class ProcessExtension
    {
        public static ProcessModel ToHydratedModel(this Process aProcess, IEnumerable<ProcessRevisionModel> aProcessRevs)
        {
            return new ProcessModel()
            {
                CustId = aProcess.CustId,
                Name = aProcess.Name,
                ProcessId = aProcess.ProcessId,
                Revisions = aProcessRevs
            };
        }

        public static ProcessModel ToModel(this Process aProcess)
        {
            return new ProcessModel()
            {
                CustId = aProcess.CustId,
                Name = aProcess.Name,
                ProcessId = aProcess.ProcessId
            };
        }
    }
}
