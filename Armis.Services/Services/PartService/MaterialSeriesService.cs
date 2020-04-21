using Armis.BusinessModels.PartModels;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.PartExtensions;
using Armis.DataLogic.Services.PartService.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.PartService
{
    public class MaterialSeriesService : IMaterialSeriesService
    {
        private ARMISContext Context;

        public MaterialSeriesService(ARMISContext aContext)
        {
            Context = aContext;
        }

        public async Task<IEnumerable<MaterialSeriesModel>> GetAllMaterialSeries()
        {
            var entities = await Context.MaterialSeries.ToListAsync();

            if(entities == null || !entities.Any()) { throw new Exception("No Material Series entities were found."); }

            return entities.ToModels();
        }
    }
}
