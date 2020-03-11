using Armis.BusinessModels.ProcessModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Process.Interfaces
{
    public interface IProcessDataAccess
    {
        Task<IEnumerable<ProcessModel>> GetAllHydratedProcesses();
        Task<ProcessModel> GetHydratedProcess(int id);
        Task<bool> CheckIfNameIsUnique(string aName);
        Task<ProcessModel> PostNewProcess(ProcessModel aProcessModel);
        Task<string> DeleteProcessRevision(int aProcessId, int aProcessRevId);
        Task<ProcessRevisionModel> RevUp(ProcessRevisionModel aProcessRevModel);
        Task<ProcessRevisionModel> LockRevision(int aProcessId, int aProcessRevId, List<StepSeqModel> aStepList);
        Task<ProcessRevisionModel> SaveStepSeqToRevision(List<StepSeqModel> aStepSeqModel);
        Task<ProcessModel> CopyToNewProcessFromExisting(ProcessModel aProcessModel);
    }
}
