using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.ModelExtensions.ProcessExtensions;
using Armis.DataLogic.Services.ProcessServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ProcessServices
{
    public class ProcessService : IProcessService
    {
        private ARMISContext context;
        public ProcessService(ARMISContext aContext)
        {
            context = aContext;
        }

        //CREATE
        public int CreateNewProcess(Process process)
        {
            if (process == null) { throw new NullReferenceException("Process cannot be null."); }
            context.Process.Add(process);

            return process.ProcessId; //This might return as null. Careful of this.
        }

        public string CreateNewRevForExistingProcess(ProcessRevision newRev)
        {
            if (newRev == null) { throw new NullReferenceException("ProcessId and NewRev cannot be null."); }

            context.Add(newRev);

            return newRev.ProcessId + " " + newRev.ProcessRevId;
        }

        //DELETE
        public Task DeleteProcess(int processId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProcessRev(int processId, int processRevId)
        {
            throw new NotImplementedException();
        }

        //READ

        public async Task<IEnumerable<Process>> GetAllProcessRevsForCustomer(int aCustomerId)
        {
            if (aCustomerId == 0) { throw new NullReferenceException("No CustomerId provided."); }

            var processEntities = await context.Process.Where(i => i.CustId == aCustomerId).Include(j => j.ProcessRevision).ToListAsync();

            if (processEntities == null) { throw new NullReferenceException("Could not find any processes where CustomerId == " + aCustomerId + "."); }

            return processEntities;
        }

        public Task<IEnumerable<ProcessRevision>> GetAllRevsForProcessId(int processId)
        {
            throw new NotImplementedException();
        }

        //UPDATE
        public Task UpdateProcess(Process process)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProcessRev(ProcessRevision processRev)
        {
            throw new NotImplementedException();
        }

        //ONLY FOR TESTING TODO:Remove the following method!!!!!!!!!!
        public async Task<string> AddStepTEST(Step aStep)
        {
            context.Add(aStep);

            return aStep.StepId.ToString();
        }

        public Task<IEnumerable<Process>> GetAllActiveProcessRevs()
        {
            throw new NotImplementedException();
        }

        public Task<ProcessModel> GetCompleteProcess(int aProcessId)
        {
            throw new NotImplementedException();
        }
    }
}
