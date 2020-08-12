using Armis.BusinessModels.PartModels;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.PartExtensions;
using Armis.DataLogic.Services.PartServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.PartServices
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

        public async Task<MaterialSeriesModel> CreateMaterialSeries(MaterialSeriesModel aMaterialSeriesModel)
        {
            var entityToAdd = aMaterialSeriesModel.ToEntity();

            var lastUsedId = await Context.MaterialSeries.MaxAsync(i => i.MaterialSeriesId);

            entityToAdd.MaterialSeriesId = (lastUsedId + 1);

            Context.MaterialSeries.Add(entityToAdd);
            await Context.SaveChangesAsync();

            return entityToAdd.ToModel();
        }
    }
}
