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
        public async Task<IEnumerable<Process>> GetAllActiveProcessRevs()
        {
            //This code is definately not ok.  Just using it as a test.  TODO: Fix this to actually be useful.
            var revEntities = await context.Process
               .Include(i => i.ProcessRevision.Where(j => j.RevStatusCd == "LOCKED"))
                   .ThenInclude(k => k.ProcessSubOprSeq)
               .Include(l => l.Cust)
                   .ThenInclude(m => m.Part).ToListAsync();

            if (revEntities == null) { throw new NullReferenceException("No active Process Revs returned."); }

            return revEntities;
        }

        //TEST CODE TODO: DELETE THIS!!!!!!
        public async Task<ProcessModel> GetCompleteProcess(int aProcessId) //TODO: SORT BY SEQ ALSO ADD NAMES TO STUFF
        {
            var theProcessEntity = await context.Process.Where(i => i.ProcessId == aProcessId)
                .Include(i => i.ProcessRevision)
                    .ThenInclude(i => i.ProcessSubOprSeq)
                        .ThenInclude(i => i.SubOpRev)
                                .ThenInclude(i => i.SubOpStepSeq)
                                    .ThenInclude(i => i.Step)
                                        .ThenInclude(i => i.StepVarSeq)
                                            .ThenInclude(i => i.StepVariable).ToListAsync();

            var theProcessModel = new ProcessModel();
            

            //There should be only one entity in this, but FirstOrDefault can't be used with .Include.  The data needs to be loaded into a list and then iterated upon, even though there is only one thing in the list.
            foreach (var process in theProcessEntity)
            {
                var theProcessRevs = new List<ProcessRevisionModel>();

                foreach (var processRev in process.ProcessRevision)
                {
                    var theSubOpRevs = new List<SubopRevisionModel>();

                    foreach (var subOpSeq in processRev.ProcessSubOprSeq)
                    {
                        var theSteps = new List<StepModel>();

                        foreach (var stepSeq in subOpSeq.SubOpRev.SubOpStepSeq)
                        {
                            theSteps.Add(stepSeq.Step.ToModel(stepSeq.StepSeq));
                        }

                        var theSupOpEntity = await context.SubOperation.FirstOrDefaultAsync(i => i.SubOpId == subOpSeq.SubOpId);

                        theSubOpRevs.Add(subOpSeq.SubOpRev.ToHydratedModel(subOpSeq, theSteps, theSupOpEntity.Name));

                    }

                    theProcessRevs.Add(processRev.ToModel(theSubOpRevs, process.Name));

                }
                theProcessModel = process.ToHydratedModel(theProcessRevs);
            }

            return theProcessModel;
        }

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

        public Task<IEnumerable<SubOpRevision>> GetAllSubOpsForProcessRevId(int processId, int processRevId)
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
    }
}
