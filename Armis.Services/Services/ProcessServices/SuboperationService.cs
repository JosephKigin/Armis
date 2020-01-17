using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.ProcessExtensions;
using Armis.DataLogic.Services.ProcessServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ProcessServices
{
    public class SuboperationService : ISubOperationService
    {
        private ARMISContext _context;

        public ARMISContext Context
        {
            get { return _context; }
            set { _context = value; }
        }


        public async Task<SubopRevisionModel> CreateRevForExistingSubop(SubopRevisionModel aSubopRevModel)
        {
            aSubopRevModel.SubOpRevId = Context.SubOpRevision.Max(i => i.SubOpRevId) + 1;

            var theRevToAdd = aSubopRevModel.ToEntity();
            theRevToAdd.RevStatusCd = "UNLOCKED";

            Context.SubOpRevision.Add(theRevToAdd);
            await Context.SaveChangesAsync();

            return aSubopRevModel;
        }

        public async Task<SubopModel> CreateSubop(SubopModel aSubopModel)
        {
            if(aSubopModel.SubOpId == 0) { aSubopModel.SubOpId = Context.SubOperation.Max(i => i.SubOpId) + 1; }

            Context.SubOperation.Add(aSubopModel.ToEntity());
            await Context.SaveChangesAsync();

            return aSubopModel;
        }

        public async Task<SubopModel> DeactivateSubop(int aSubopId)
        {
            var theRevsToRemoveEntities = await Context.SubOpRevision.Where(i => i.SubOpId == aSubopId).ToListAsync();
            var theSubOpEntity = await Context.SubOperation.SingleOrDefaultAsync(i => i.SubOpId == aSubopId);

            theRevsToRemoveEntities.ForEach(i => i.RevStatusCd = "INACTIVE");
            await Context.SaveChangesAsync();

            var theSubopModel = theSubOpEntity.ToModel();
            var theRevModels = new List<SubopRevisionModel>();

            theRevsToRemoveEntities.ForEach(i => theRevModels.Add(i.ToModel()));
            theSubopModel.Revs = theRevModels;            

            return theSubopModel;
        }

        public async Task<SubopRevisionModel> DeactivateSubopRev(int aSubopId, int aSubopRevId)
        {
            var theToInactiveRevEntity = await Context.SubOpRevision.FirstOrDefaultAsync(i => i.SubOpId == aSubopId && i.SubOpRevId == aSubopRevId);

            theToInactiveRevEntity.RevStatusCd = "INACTIVE";

            await Context.SaveChangesAsync();

            return theToInactiveRevEntity.ToModel();
        }

        public async Task<SubopRevisionModel> LockSubopRev(SubopRevisionModel aSubopRevModel)
        {
            var theToLockRevEntity = await Context.SubOpRevision.FirstOrDefaultAsync(i => i.SubOpId == aSubopRevModel.SubOpId && i.SubOpRevId == aSubopRevModel.SubOpRevId);
            try { await DeactivateSubopRev(aSubopRevModel.SubOpId, aSubopRevModel.SubOpRevId - 1); }
            catch (Exception ex) { throw new Exception("Unable to deactivate previous subop. " + ex.Message); } //TODO: Figure out how to tell the front-end that there isn't a SupOp to deactivate.  Is that better?
            

            theToLockRevEntity.RevStatusCd = "LOCKED";

            await Context.SaveChangesAsync();

            return theToLockRevEntity.ToModel();
        }
    }
}
