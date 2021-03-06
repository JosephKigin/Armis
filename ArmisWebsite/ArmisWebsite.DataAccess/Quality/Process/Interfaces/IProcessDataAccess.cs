﻿using Armis.BusinessModels.QualityModels.PassBackModels;
using Armis.BusinessModels.QualityModels.Process;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Quality.Interfaces
{
    public interface IProcessDataAccess
    {
        Task<IEnumerable<ProcessModel>> GetAllHydratedProcesses();
        Task<ProcessModel> GetHydratedProcess(int id);
        Task<IEnumerable<ProcessModel>> GetHydratedProcessesWithCurrentLockedRev();
        Task<IEnumerable<ProcessModel>> GetHydratedProcessesWithCurrentAnyRev();
        Task<ProcessRevisionModel> GetHydratedCurrentProcessRev(int aProcessId);
        Task<bool> CheckIfNameIsUnique(string aProcessName);
        Task<ProcessModel> PostNewProcess(ProcessModel aProcessModel);
        Task<string> DeleteProcessRevision(int aProcessId, int aProcessRevId);
        Task<ProcessRevisionModel> RevUp(ProcessRevisionModel aProcessRevModel);
        Task<ProcessRevisionModel> LockRevision(PassBackProcessRevStepSeqModel aPassBackModel);
        Task<ProcessRevisionModel> SaveStepSeqToRevision(List<StepSeqModel> aStepSeqModel);
        Task<ProcessModel> CopyToNewProcessFromExisting(ProcessModel aProcessModel);
    }
}
