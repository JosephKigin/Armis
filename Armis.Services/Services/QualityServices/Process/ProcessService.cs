using Armis.BusinessModels.QualityModels.Process;
using Armis.Data.DatabaseContext;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.ModelExtensions.QualityExtensions.ProcessExtensions;
using Armis.DataLogic.Services.QualityServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.QualityServices
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
            var processEntity = process.ToEntity();

            var lastUsedId = await context.Process.MaxAsync(i => i.ProcessId);

            processEntity.ProcessId = lastUsedId + 1;

            if(process.Revisions.Count() > 1) { throw new Exception("Cannot save a process and multiple revisions at once"); }

            var theRevision = process.Revisions.FirstOrDefault();

            theRevision.DateTimeCreated = DateTime.Now;
            theRevision.ProcessId = processEntity.ProcessId;
            theRevision.ProcessRevId = 1; //This is the first revision of a new process, so it should always be 1.
            theRevision.RevStatusId = 2; //The revisions will start as UNLOCKED.

            processEntity.ProcessRevision.Add(theRevision.ToEntity());

            context.Process.Add(processEntity);
            await context.SaveChangesAsync();

            return processEntity.ToModel();
        }

        //Takes a current process and makes a copy of it with the only revision on it being the locked rev of the existing process
        public async Task<ProcessModel> CopyToNewProcessFromExisting(ProcessModel aProcessModel)
        {
            var theProcessEntity = aProcessModel.ToEntity();
            var lastUsedProcessId = await context.Process.MaxAsync(i => i.ProcessId);
            theProcessEntity.ProcessId = lastUsedProcessId + 1;

            //Grabs the locked revision of the process being copied.
            var theOldRevisionEntity = await context.ProcessRevision.Where(i => i.ProcessId == aProcessModel.ProcessId && i.RevStatusId == 1) //1 = LOCKED
                                                            .Include(i => i.ProcessStepSeq)
                                                                .ThenInclude(i => i.Operation)
                                                                    .ThenInclude(i => i.OperGroup)
                                                            .Include(i => i.ProcessStepSeq)
                                                                .ThenInclude(i => i.Step).FirstOrDefaultAsync();
            var theRevisionEntity = new ProcessRevision();
            theRevisionEntity.ProcessRevId = 1;
            theRevisionEntity.RevStatusId = 2; //2 = UNLOCKED
            theRevisionEntity.DateCreated = DateTime.Now;
            theRevisionEntity.TimeCreated = DateTime.Now.TimeOfDay;
            theRevisionEntity.ProcessId = theProcessEntity.ProcessId;
            theRevisionEntity.Comments = aProcessModel.Revisions.FirstOrDefault().Comments;
            theRevisionEntity.CreatedByEmp = aProcessModel.Revisions.FirstOrDefault().CreatedByEmp;

            var theNewStepSeqEntities = new List<ProcessStepSeq>();

            foreach (var stepSeq in theOldRevisionEntity.ProcessStepSeq)
            {
                theNewStepSeqEntities.Add(new ProcessStepSeq
                {
                    StepId = stepSeq.StepId,
                    StepSeq = stepSeq.StepSeq,
                    ProcessId = theProcessEntity.ProcessId,
                    ProcessRevId = theRevisionEntity.ProcessRevId,
                    OperationId = stepSeq.OperationId
                });
            }

            theRevisionEntity.ProcessStepSeq = theNewStepSeqEntities;
            theProcessEntity.ProcessRevision.Add(theRevisionEntity);

            context.Process.Add(theProcessEntity);

            await context.SaveChangesAsync();

            var result = await GetHydratedProcess(theProcessEntity.ProcessId);

            return result;
        }

        public async Task<ProcessRevisionModel> CreateNewRevForExistingProcess(ProcessRevisionModel newRev) //This parameter needs comment, employee number, and processId
        {
            var newRevEntity = newRev.ToEntity();
            newRevEntity.RevStatusId = 2; //2 = UNLOCKED
            var currentRevs = await context.ProcessRevision.Where(i => i.ProcessId == newRev.ProcessId).Include(i => i.ProcessStepSeq).ToListAsync();
            var currentRev = (currentRevs != null && currentRevs.Any()) ? currentRevs.OrderByDescending(i => i.ProcessRevId).First() : null;


            if (currentRevs == null || !currentRevs.Any())
            {
                newRevEntity.ProcessRevId = 1;
            }
            else if (currentRev.RevStatusId == 2) //2 = UNLOCKED
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
            newRevEntity.DateCreated = DateTime.Now; //TODO: Move this to entity extension just like spec rev is.
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
                                                            .ThenInclude(i => i.Step)
                                                                .ThenInclude(i => i.StepCategory).ToListAsync();
            var result = entities.ToHydratedModels();

            return result;
        }

        public async Task<IEnumerable<ProcessModel>> GetHydratedProcessesWithCurrentRev()
        {
            //This code won't work until Entity Framework Core 5.0 is release, expected release dat is November 2020.  TODO: Check back with this in November 2020.
            //var entities = await context.Process.Include(i => i.ProcessRevision.Where(i => i.RevStatusId == 1)) 
            //                                        .ThenInclude(i => i.ProcessStepSeq)
            //                                                .ThenInclude(i => i.Operation)
            //                                                    .ThenInclude(i => i.OperGroup)
            //                                         .Include(i => i.ProcessRevision)
            //                                            .ThenInclude(i => i.ProcessStepSeq)
            //                                                .ThenInclude(i => i.Step)
            //                                                    .ThenInclude(i => i.StepCategory).ToListAsync();
            //var result = entities.ToHydratedModels();

            //return result;

            var processModels = await GetHydratedProcessRevs();

            foreach (var processModel in processModels)
            {
                if (processModel.Revisions.Any())
                {
                    var maxRevId = processModel.Revisions.Max(i => i.ProcessRevId);
                    var tempRevList = processModel.Revisions.ToList();
                    foreach (var rev in processModel.Revisions)
                    {
                        if (rev.RevStatusId != 1)
                        {
                            tempRevList.Remove(rev);
                        }
                    }
                    processModel.Revisions = tempRevList;
                }
            }

            return processModels;
        }

        public async Task<ProcessModel> GetHydratedProcess(int aProcessId)
        {
            var processEntity = await context.Process.Where(i => i.ProcessId == aProcessId)
                                                     .Include(i => i.ProcessRevision)
                                                        .ThenInclude(i => i.ProcessStepSeq)
                                                            .ThenInclude(i => i.Operation)
                                                                .ThenInclude(i => i.OperGroup)
                                                     .Include(i => i.ProcessRevision)
                                                        .ThenInclude(i => i.ProcessStepSeq)
                                                            .ThenInclude(i => i.Step)
                                                                .ThenInclude(i => i.StepCategory).SingleOrDefaultAsync();

            if (processEntity == null) { throw new NullReferenceException("No process with id " + aProcessId + " exists."); }

            return processEntity.ToHydratedModel();
        }

        public async Task<ProcessRevisionModel> GetHydratedCurrentProcessRev(int aProcessId)
        {
            var entity = await context.ProcessRevision.Where(i => i.ProcessId == aProcessId).OrderByDescending(i => i.ProcessRevId)
                                                            .Include(i => i.ProcessStepSeq)
                                                                .ThenInclude(i => i.Operation)
                                                                    .ThenInclude(i => i.OperGroup)
                                                            .Include(i => i.ProcessStepSeq)
                                                                .ThenInclude(i => i.Step)
                                                                    .ThenInclude(i => i.StepCategory).FirstOrDefaultAsync();

            if (entity == null) { throw new NullReferenceException("No process with id " + aProcessId + " exists."); }

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

            await context.SaveChangesAsync();

            return theProcessToUpdate.ToModel();
        }

        public async Task<ProcessRevisionModel> UpdateStepsForRev(IEnumerable<StepSeqModel> aStepSeqs)
        {
            var firstStepSeq = aStepSeqs.First();  //This is only used for pulling the rev and process id.  All step sequences in aStepSeqs have the same process and revision id.
            var theRev = await context.ProcessRevision.Include(i => i.ProcessStepSeq).FirstOrDefaultAsync(i => i.ProcessId == firstStepSeq.ProcessId && i.ProcessRevId == firstStepSeq.RevisionId);

            if (theRev.RevStatusId == 1 || theRev.RevStatusId == 3) //1 = LOCKED, 3 = INACTVIE
            {
                throw new InvalidOperationException("Cannot change steps on a locked or inactive revision. \r\n" + DateTime.Now);
            }

            if (theRev.ProcessStepSeq != null && theRev.ProcessStepSeq.Any())
            {
                foreach (var stepSeq
                    in theRev.ProcessStepSeq) //Delete all step seq current for that rev.
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

            if (currentRev.RevStatusId != 2) //2 = UNLOCKED
            {
                throw new InvalidOperationException("The most current revision for that process is not unlocked. \r\n" + DateTime.Now);
            }

            if (currentRev.ProcessRevId > 1)
            {
                var previousRev = await context.ProcessRevision.FirstOrDefaultAsync(i => i.ProcessId == currentRev.ProcessId && i.ProcessRevId == currentRev.ProcessRevId - 1);

                if (previousRev.RevStatusId != 1) //1 = LOCKED; The previous revision before the unlocked needs to be locked.
                {
                    throw new InvalidOperationException("The previous revision of this unlocked revision is not locked.  Process Id: " + aProcessId + "\r\n" + DateTime.Now);
                }

                previousRev.RevStatusId = 3; //3 = INACTIVE
            }

            currentRev.RevStatusId = 1; //1 = LOCKED

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

            if (entity.RevStatusId != 2) //2 = UNLOCKED
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
