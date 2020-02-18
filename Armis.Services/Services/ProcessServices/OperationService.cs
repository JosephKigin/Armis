using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.ProcessExtensions;
using Armis.DataLogic.Services.ProcessServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ProcessServices
{
    public class OperationService : IOperationService
    {
        private readonly ARMISContext context;

        public OperationService(ARMISContext aContext)
        {
            context = aContext;
        }

        public async Task<IEnumerable<OperationModel>> GetAllOperations()
        {
            var entities = await context.Operation.ToListAsync();

            return entities.ToModels();
        }
    }
}
