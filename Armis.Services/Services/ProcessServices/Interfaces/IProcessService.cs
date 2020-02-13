using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ProcessServices.Interfaces
{
    public interface IProcessService
    {
        //READ
        Task<IEnumerable<ProcessModel>> GetAllProcesses();
        Task<ProcessModel> GetHydratedProcess(int processId);
        Task<IEnumerable<ProcessModel>> GetHydratedProcessRevs();
        Task<ProcessRevisionModel> GetCurrentProcessRevWithSteps(int aProcessId);
        Task<bool> CheckIfNameIsUnique(string aName);

        //CREATE
        Task<ProcessRevisionModel> CreateNewRevForExistingProcess(ProcessRevisionModel newRev);
        Task<ProcessModel> CreateNewProcess(ProcessModel process);  //Returns ProcessId

        //UPDATE
        Task<ProcessModel> UpdateProcess(Process process);
        Task<ProcessRevisionModel> UpdateStepsForRev(IEnumerable<StepSeqModel> aStepSeqs);
        Task<ProcessRevisionModel> UpdateUnlockToLockRev(ProcessRevisionModel aProcessRevModel);

        //DELETE
        Task DeleteProcess(int processId); //Must delete all revs linked to this process
        Task DeleteProcessRev(ProcessRevisionModel aProcessRevModel);
    }
}
