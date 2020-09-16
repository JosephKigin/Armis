using Armis.BusinessModels.PartModels;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.PartExtensions;
using Armis.DataLogic.Services.PartServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.PartServices
{
    public class HardnessService : IHardnessService
    {
        private ARMISContext Context;

        public HardnessService(ARMISContext aContext)
        {
            Context = aContext;
        }

        public async Task<IEnumerable<HardnessModel>> GetAllHarnesses()
        {
            var theHardnessEntities = await Context.Hardness.ToListAsync();

            if(theHardnessEntities == null || !theHardnessEntities.Any()) { return null; /*throw new Exception("No Hardnesses were returned");*/ }

            return theHardnessEntities.ToModels();
        }

        public async Task<HardnessModel> GetHardness(int aHardnessId)
        {
            var theHardnessEntity = await Context.Hardness.FindAsync(aHardnessId);

            if(theHardnessEntity == null) { throw new Exception("No hardness was found."); }

            return theHardnessEntity.ToModel();
        }

        public async Task<bool> CheckIsNameIsUnique(string aHardnessName)
        {
            var entity = await Context.Hardness.FirstOrDefaultAsync(i => i.ShortName == aHardnessName);

            if(entity == null) { return true; }
            else { return false; }
        }

        public async Task<HardnessModel> CreateHardness(HardnessModel aHardnessModel)
        {
            var entityToAdd = aHardnessModel.ToEntity();

            int lastIdUsed = 1;
            if (Context.Hardness.Any())
            { lastIdUsed = await Context.Hardness.MaxAsync(i => i.HardnessId); }
                
            entityToAdd.HardnessId = (lastIdUsed + 1);

            Context.Hardness.Add(entityToAdd);
            await Context.SaveChangesAsync();

            return entityToAdd.ToModel();
        }
    }
}
