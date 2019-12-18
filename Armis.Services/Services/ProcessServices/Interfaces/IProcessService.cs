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
        Task<IEnumerable<Process>> GetAllActiveProcessRevs();
        Task<IEnumerable<ProcessRevision>> GetAllRevsForProcessId(int processId);
        Task<IEnumerable<Process>> GetAllProcessRevsForCustomer(int cutomerId);
        Task<IEnumerable<SubOpRevision>> GetAllSubOpsForProcessRevId(int processId, int processRevId);

        //CREATE
        string CreateNewRevForExistingProcess(ProcessRevision newRev);
        int CreateNewProcess(Process process);  //Returns ProcessId

        //UPDATE
        Task UpdateProcess(Process process);
        Task UpdateProcessRev(ProcessRevision processRev);

        //DELETE
        Task DeleteProcess(int processId); //Must delete all revs linked to this process
        Task DeleteProcessRev(int processId, int processRevId);

        //Test code TODO: DELETE THIS
        Task<ProcessModel> GetCompleteProcess(int aProcessId);
    }
}
