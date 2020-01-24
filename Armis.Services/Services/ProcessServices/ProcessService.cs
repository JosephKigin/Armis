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
        public Task<ProcessModel> CreateNewProcess(Process process)
        {
            throw new NotImplementedException();
        }

        public Task<ProcessRevisionModel> CreateNewRevForExistingProcess(ProcessRevision newRev)
        {
            throw new NotImplementedException();
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

        public async Task<IEnumerable<ProcessModel>> GetAllProcessRevsForCustomer(int aCustomerId)
        {
            var processEntities = await context.Process.Where(i => i.CustId == aCustomerId).Include(i => i.ProcessRevision).ToListAsync();

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

        public async Task<ProcessModel> GetHydratedProcess(int processId)
        {
            var processEntity = await context.Process.Where(i => i.ProcessId == processId)
                                                     .Include(i => i.ProcessRevision)
                                                        .ThenInclude(i => i.ProcessStepSeq)
                                                            .ThenInclude(i => i.Operation)
                                                                .ThenInclude(i => i.OperGroup)
                                                     .Include(i => i.ProcessRevision)
                                                        .ThenInclude(i => i.ProcessStepSeq)
                                                            .ThenInclude(i => i.Step).SingleOrDefaultAsync();

            if(processEntity == null) { throw new NullReferenceException("No process with id " + processId + " exists."); }

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

        //Update
        public Task<ProcessModel> UpdateProcess(Process process)
        {
            throw new NotImplementedException();
        }

        public Task<ProcessRevisionModel> UpdateProcessRev(ProcessRevision processRev)
        {
            throw new NotImplementedException();
        }
    }
}
