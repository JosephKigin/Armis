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

        public Task<ProcessRevisionModel> CreateNewRevForExistingProcess(ProcessRevision newRev)
        {
            throw new NotImplementedException();
        }

        public async Task TestCreateProcess()
        {
            //var revs = new List<ProcessRevision>();

            //var rev1 = new ProcessRevision()
            //{
            //    ProcessRevId = 1,
            //    ProcessId = 1,
            //    CreatedByEmp = 991,
            //    DateCreated = DateTime.Now.Date,
            //    TimeCreated = DateTime.Now.TimeOfDay,
            //    RevStatusCd = "INACTIVE",
            //    DueDays = 4,
            //    Comments = "This is a test."
            //};

            //var rev2 = new ProcessRevision()
            //{
            //    ProcessRevId = 2,
            //    ProcessId = 1,
            //    CreatedByEmp = 991,
            //    DateCreated = DateTime.Now.Date,
            //    TimeCreated = DateTime.Now.TimeOfDay,
            //    RevStatusCd = "LOCKED",
            //    DueDays = 4,
            //    Comments = "This is a second test."
            //};

            //revs.Add(rev1);
            //revs.Add(rev2);

            //var result = new Process()
            //{
            //    CustId = 1,
            //    Name = "TEST PROCESS",
            //    ProcessId = 1,
            //    ProcessRevision = revs
            //};

            //context.Process.Add(result);

            var removeDisThang = await context.Process.Where(i => i.ProcessId == 1).Include(i => i.ProcessRevision).FirstOrDefaultAsync();
            context.RemoveRange(removeDisThang.ProcessRevision);
            context.Remove(removeDisThang);
            await context.SaveChangesAsync();
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

            if(entity != null) { return false; }
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

        public async Task<ProcessRevisionModel> UpdateProcessRev(ProcessRevision aProcessRev)
        {
            var currentRev = await context.ProcessRevision.SingleOrDefaultAsync(i => i.ProcessId == aProcessRev.ProcessId && i.ProcessRevId == aProcessRev.ProcessRevId);

            if (currentRev.RevStatusCd == "LOCKED")
            {
                aProcessRev.ProcessRevId = currentRev.ProcessRevId + 1;
            }
            else if (currentRev.RevStatusCd == "UNLOCKED")
            {
                aProcessRev.ProcessRevId = currentRev.ProcessRevId;
            }
            else if(currentRev.RevStatusCd == "")
            {
                throw new Exception("");
            }
            return new ProcessRevisionModel();
        }

        //Delete
        public Task DeleteProcess(int processId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProcessRev(int processId, int processRevId)
        {
            throw new NotImplementedException();
        }
    }
}
