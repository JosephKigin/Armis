using Armis.BusinessModels.ProcessModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Process.Interfaces
{
    public interface IProcessDataAccess
    {
        Task<IEnumerable<ProcessModel>> GetAllProcesses();
        Task<IEnumerable<ProcessModel>> GetAllHydratedProcesses();
        Task<bool> CheckIfNameIsUnique(string aName);
        Task<ProcessModel> PostNewProcess(ProcessModel aProcessModel);
        Task<string> DeleteProcessRevision(int aProcessId, int aProcessRevId);
        Task<ProcessRevisionModel> RevUp(ProcessRevisionModel aProcessRevModel);
    }
}
