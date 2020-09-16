using Armis.BusinessModels.PartModels;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.PartExtensions;
using Armis.DataLogic.Services.PartServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.PartServices
{
    public class UnitOfMeasureService : IUnitOfMeasureService
    {
        private ARMISContext Context;

        public UnitOfMeasureService(ARMISContext aContext)
        {
            Context = aContext;
        }

        public async Task<IEnumerable<UnitOfMeasureModel>> GetAllUoMs()
        {
            var entities = await Context.UnitOfMeasure.ToListAsync();

            if(entities == null) { throw new Exception("No Unit of Measures were returned."); }

            return entities.ToModels();
        }
    }
}
