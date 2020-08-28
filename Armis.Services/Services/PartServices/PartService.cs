using Armis.BusinessModels.PartModels;
using Armis.Data.DatabaseContext;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.ModelExtensions.PartExtensions;
using Armis.DataLogic.Services.PartServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Armis.DataLogic.Services.PartServices
{
    public class PartService : IPartService
    {
        private ARMISContext Context;

        public PartService(ARMISContext aContext)
        {
            Context = aContext;
        }

        //CREATE
        public async Task<PartModel> CreatePart(PartModel aPart)
        {
            var entityToAdd = aPart.ToEntity();

            entityToAdd.PartId = (await Context.Part.MaxAsync(i => i.PartId)) + 1;

            Context.Part.Add(entityToAdd);

            await Context.SaveChangesAsync();

            return entityToAdd.ToModel();
        }

        //READ
        //Will only ever pull parts that are active
        public async Task<IEnumerable<PartModel>> GetAllParts()
        {
            var entities = await Context.Part.Where(i => i.Inactive == false).IncludeOptimized(i => i.SurfaceAreaUoMNavigation).ToListAsync();

            if (entities == null || !entities.Any()) { throw new Exception("No parts were returned"); }

            return entities.ToModels();
        }

        public async Task<IEnumerable<PartModel>> GetAllHydratedParts()
        {
            var entities = await Context.Part.Where(i => i.Inactive == false)
                                                   .IncludeOptimized(i => i.SurfaceAreaUoMNavigation)
                                                   .IncludeOptimized(i => i.MaterialAlloy)
                                                   .IncludeOptimized(i => i.CreatedByEmpNavigation)
                                                   .IncludeOptimized(i => i.MaterialSeries)
                                                   .IncludeOptimized(i => i.StandardDeptNavigation)
                                                   .IncludeOptimized(i => i.Rack)
                                                   .ToListAsync();

            if(entities == null || !entities.Any()) { throw new Exception("No parts were returned"); }

            return entities.ToHydratedModels();                                 
        }

        public async Task<IEnumerable<PartModel>> GetPartsForCustId(int aCustId)
        {
            var entities = await Context.CustomerPart.Where(i => i.CustId == aCustId).ToListAsync();

            if (entities == null || !entities.Any()) { return null; }

            var partEntities = new List<Part>();
            foreach (var entity in entities)
            {
                var partEntity = await Context.Part.IncludeOptimized(i => i.CreatedByEmpNavigation)
                                                   .IncludeOptimized(i => i.MaterialAlloy)
                                                   .IncludeOptimized(i => i.MaterialSeries)

                                                   .FirstOrDefaultAsync(i => i.PartId == entity.PartId);
                partEntities.Add(partEntity);
            }

            return partEntities.ToHydratedModels();
        }
    }
}
