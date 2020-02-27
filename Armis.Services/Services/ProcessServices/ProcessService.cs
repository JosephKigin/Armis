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

        //Create
        public async Task<ProcessModel> CreateNewProcess(ProcessModel process)
        {
            var entity = process.ToEntity();

            var lastUsedId = await context.Process.MaxAsync(i => i.ProcessId);

            entity.ProcessId = lastUsedId + 1;

            context.Process.Add(entity);
            await context.SaveChangesAsync();

            return entity.ToModel();
        }

        public async Task<ProcessRevisionModel> CreateNewRevForExistingProcess(ProcessRevisionModel newRev) //This parameter needs comment, employee number, and processId
        {
            var newRevEntity = newRev.ToEntity();
            newRevEntity.RevStatusCd = "UNLOCKED";
            var currentRevs = await context.ProcessRevision.Where(i => i.ProcessId == newRev.ProcessId).Include(i => i.ProcessStepSeq).ToListAsync();
            var currentRev = (currentRevs != null && currentRevs.Any()) ? currentRevs.OrderByDescending(i => i.ProcessRevId).First() : null;


            if (currentRevs == null || !currentRevs.Any())
            {
                newRevEntity.ProcessRevId = 1;
            }
            else if (currentRev.RevStatusCd == "UNLOCKED")
            {
                throw new InvalidOperationException("Cannot Rev-Up a process whose most current revision is unlocked.");
            }
            else
            {
                newRevEntity.ProcessRevId = currentRev.ProcessRevId + 1;
                foreach (var stepSeq in currentRev.ProcessStepSeq)
                {
                    var newStepSeq = new ProcessStepSeq()
                    {
                        ProcessRevId = newRevEntity.ProcessRevId,
                        OperationId = stepSeq.OperationId,
                        ProcessId = stepSeq.ProcessId,
                        StepId = stepSeq.StepId,
                        StepSeq = stepSeq.StepSeq
                    };
                    newRevEntity.ProcessStepSeq.Add(newStepSeq);
                }
            }
            newRevEntity.DateCreated = DateTime.Now;
            newRevEntity.TimeCreated = DateTime.Now.TimeOfDay;
            context.ProcessRevision.Add(newRevEntity);
            await context.SaveChangesAsync();

            return newRevEntity.ToModel();
        }

        //Read
        public async Task<IEnumerable<ProcessModel>> GetAllProcesses()
        {
            var processEntities = await context.Process.Include(i => i.ProcessRevision).ToListAsync();

            var result = new List<ProcessModel>();

            foreach (var entity in processEntities)
            {
                var theRevs = new List<ProcessRevisionModel>();

                foreach (var rev in entity.ProcessRevision)
                { theRevs.Add(rev.ToModel()); }

                result.Add(entity.ToHydratedModel(theRevs));
            }

            return result;
        }

        public async Task<IEnumerable<ProcessModel>> GetHydratedProcessRevs()
        {
            var entities = await context.Process.Include(i => i.ProcessRevision)
                                                    .ThenInclude(i => i.ProcessStepSeq)
                                                            .ThenInclude(i => i.Operation)
                                                                .ThenInclude(i => i.OperGroup)
                                                     .Include(i => i.ProcessRevision)
                                                        .ThenInclude(i => i.ProcessStepSeq)
                                                            .ThenInclude(i => i.Step).ToListAsync();
            var result = entities.ToHydratedModels();

            return result;
        }

        public async Task<ProcessModel> GetHydratedProcess(int processId) //TODO: Use the hydrated extension.
        {
            var processEntity = await context.Process.Where(i => i.ProcessId == processId)
                                                     .Include(i => i.ProcessRevision)
                                                        .ThenInclude(i => i.ProcessStepSeq)
                                                            .ThenInclude(i => i.Operation)
                                                                .ThenInclude(i => i.OperGroup)
                                                     .Include(i => i.ProcessRevision)
                                                        .ThenInclude(i => i.ProcessStepSeq)
                                                            .ThenInclude(i => i.Step).SingleOrDefaultAsync();

            if (processEntity == null) { throw new NullReferenceException("No process with id " + processId + " exists."); }

            var revs = new List<ProcessRevisionModel>();

            foreach (var rev in processEntity.ProcessRevision)
            {
                var revSteps = new List<StepModel>();

                foreach (var stepSeq in rev.ProcessStepSeq)
                {
                    var step = stepSeq.Step.ToModel(stepSeq.StepSeq, stepSeq.Operation.ToModel());
                    revSteps.Add(step);
                }

                revs.Add(rev.ToHydratedModel(revSteps));
            }

            return processEntity.ToHydratedModel(revs);
        }

        public async Task<ProcessRevisionModel> GetCurrentProcessRevWithSteps(int aProcessId)
        {
            var entity = await context.ProcessRevision.Where(i => i.ProcessId == aProcessId).OrderByDescending(i => i.ProcessRevId)
                                                            .Include(i => i.ProcessStepSeq)
                                                                .ThenInclude(i => i.Operation)
                                                                    .ThenInclude(i => i.OperGroup)
                                                            .Include(i => i.ProcessStepSeq)
                                                                .ThenInclude(i => i.Step).FirstOrDefaultAsync();

            return entity.ToHydratedModel();
        }

        public async Task<bool> CheckIfNameIsUnique(string aName)
        {
            var entity = await context.Process.FirstOrDefaultAsync(i => i.Name == aName);

            if (entity != null) { return false; }
            else { return true; }
        }

        //Update
        public async Task<ProcessModel> UpdateProcess(Process process)
        {
            var theProcessToUpdate = await context.Process.SingleOrDefaultAsync(i => i.ProcessId == process.ProcessId);

            theProcessToUpdate.Name = process.Name;
            theProcessToUpdate.CustId = process.CustId;

            await context.SaveChangesAsync();

            return theProcessToUpdate.ToModel();
        }

        public async Task<ProcessRevisionModel> UpdateStepsForRev(IEnumerable<StepSeqModel> aStepSeqs)
        {
            var firstStepSeq = aStepSeqs.First();  //This is only used for pulling the rev and process id.  All step sequences in aStepSeqs have the same process and revision id.
            var theRev = await context.ProcessRevision.Include(i => i.ProcessStepSeq).FirstOrDefaultAsync(i => i.ProcessId == firstStepSeq.ProcessId && i.ProcessRevId == firstStepSeq.RevisionId);

            if (theRev.RevStatusCd == "LOCKED" || theRev.RevStatusCd == "INACTIVE")
            {
                throw new InvalidOperationException("Cannot change steps on a locked or inactive revision. \r\n" + DateTime.Now);
            }

            if (theRev.ProcessStepSeq != null && theRev.ProcessStepSeq.Any())
            {
                foreach (var stepSeq in theRev.ProcessStepSeq) //Delete all step seq current for that rev.
                {
                    context.ProcessStepSeq.Remove(stepSeq);
                }
            }

            context.ProcessStepSeq.AddRange(aStepSeqs.ToEntities());
            await context.SaveChangesAsync();

            var result = await context.ProcessRevision.Include(i => i.ProcessStepSeq).FirstOrDefaultAsync(i => i.ProcessId == firstStepSeq.ProcessId && i.ProcessRevId == firstStepSeq.RevisionId);

            return result.ToModel();
        }

        public async Task<ProcessRevisionModel> UpdateUnlockToLockRev(int aProcessId, int aRevId)
        {
            //Grabs the current revision with the ProcessId and Revision Id being passed in.  This revision NEEDS to be locked.
            var currentRev = await context.ProcessRevision.FirstOrDefaultAsync(i => i.ProcessId == aProcessId && i.ProcessRevId == aRevId);

            if (currentRev.RevStatusCd != "UNLOCKED")
            {
                throw new InvalidOperationException("The most current revision for that process is not unlocked. \r\n" + DateTime.Now);
            }

            if (currentRev.ProcessRevId > 1)
            {
                var previousRev = await context.ProcessRevision.FirstOrDefaultAsync(i => i.ProcessId == currentRev.ProcessId && i.ProcessRevId == currentRev.ProcessRevId - 1);

                if (previousRev.RevStatusCd != "LOCKED") //The previous revision before the unlocked needs to be locked.
                {
                    throw new InvalidOperationException("The previous revision of this unlocked revision is not locked.  Process Id: " + aProcessId + "\r\n" + DateTime.Now);
                }

                previousRev.RevStatusCd = "INACTIVE";
            }

            currentRev.RevStatusCd = "LOCKED";

            await context.SaveChangesAsync();

            return currentRev.ToModel();
        }

        //Delete
        public Task DeleteProcess(int processId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteProcessRev(int aProcessId, int aProcessRevId)
        {
            var entity = await context.ProcessRevision.FirstOrDefaultAsync(i => i.ProcessId == aProcessId && i.ProcessRevId == aProcessRevId);

            if (entity.RevStatusCd != "UNLOCKED")
            {
                throw new InvalidOperationException("Cannot delete a Process Revision that isn't unlocked. \r\n" + DateTime.Now);
            }

            context.ProcessRevision.Remove(entity);

            var stepSeqEntities = await context.ProcessStepSeq.Where(i => i.ProcessId == aProcessId && i.ProcessRevId == aProcessRevId).ToListAsync();

            context.ProcessStepSeq.RemoveRange(stepSeqEntities);

            await context.SaveChangesAsync();
        }
    }
}
