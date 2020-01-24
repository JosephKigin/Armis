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
        Task<IEnumerable<ProcessModel>> GetAllProcessRevsForCustomer(int aCustomerId);

        //CREATE
        Task<ProcessRevisionModel> CreateNewRevForExistingProcess(ProcessRevision newRev);
        Task<ProcessModel> CreateNewProcess(Process process);  //Returns ProcessId

        //UPDATE
        Task<ProcessModel> UpdateProcess(Process process);
        Task<ProcessRevisionModel> UpdateProcessRev(ProcessRevision processRev);

        //DELETE
        Task DeleteProcess(int processId); //Must delete all revs linked to this process
        Task DeleteProcessRev(int processId, int processRevId);
    }
}
