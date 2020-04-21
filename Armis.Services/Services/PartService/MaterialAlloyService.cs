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
    public class MaterialAlloyService : IMaterialAlloyService
    {
        private ARMISContext Context;

        public MaterialAlloyService(ARMISContext aContext)
        {
            Context = aContext;
        }

        public async Task<IEnumerable<MaterialAlloyModel>> GetAllMaterialAlloys()
        {
            var entities = await Context.MaterialAlloy.ToListAsync();

            if(entities == null || !entities.Any()) { throw new Exception("No Material Alloys entities were found."); }

            return entities.ToModels();
        }
    }
}
