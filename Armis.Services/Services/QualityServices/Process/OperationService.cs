using Armis.BusinessModels.QualityModels.Process;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.QualityExtensions.ProcessExtensions;
using Armis.DataLogic.Services.QualityServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.QualityServices
{
    public class OperationService : IOperationService
    {
        private ARMISContext context;

        public OperationService(ARMISContext aContext)
        {
            context = aContext;
        }

        //Get
        public async Task<IEnumerable<OperationModel>> GetAllOperations()
        {
            var entities = await context.Operation.Include(i => i.OperGroup).ToListAsync();

            return entities.ToModels();
        }

        public async Task<IEnumerable<OperationGroupModel>> GetAllOperationGroups()
        {
            var entities = await context.OperationGroup.ToListAsync();

            return entities.ToModels();
        }

        //Post
        public async Task<OperationModel> AddOperation(OperationModel anOperation)
        {
            var theOperEntityToAdd = anOperation.ToEntity();

            var theMostRecentId = await context.Operation.MaxAsync(i => i.OperationId);

            var theOperationGroup = await context.OperationGroup.FirstOrDefaultAsync(i => i.OperGroupId == anOperation.Group.Id);

            theOperEntityToAdd.OperationId = theMostRecentId + 1;
            theOperEntityToAdd.OperGroup = theOperationGroup;
            context.Add(theOperEntityToAdd);
            await context.SaveChangesAsync();

            return theOperEntityToAdd.ToModel();
        }

        //Put
        public async Task<OperationModel> UpdateOperation(OperationModel anOperationModel) //This model NEEDS to have an Id with it.
        {
            var theOperationToUpdate = await context.Operation.FirstOrDefaultAsync(i => i.OperationId == anOperationModel.Id);

            theOperationToUpdate.Name = anOperationModel.Name;
            theOperationToUpdate.OperationCd = anOperationModel.OperShortName;
            theOperationToUpdate.DefaultDueDays = anOperationModel.DefaultDueDays;
            theOperationToUpdate.ThicknessIsRequired = anOperationModel.ThicknessIsRequired;
            theOperationToUpdate.OperGroup = await context.OperationGroup.FirstOrDefaultAsync(i => i.OperGroupId == anOperationModel.Group.Id);

            context.Operation.Update(theOperationToUpdate);

            await context.SaveChangesAsync();

            return theOperationToUpdate.ToModel();
        }
    }
}
