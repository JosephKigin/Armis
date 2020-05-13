using Armis.BusinessModels.QualityModels.Spec;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.QualityExtensions.SpecExtensions;
using Armis.DataLogic.Services.QualityServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.QualityServices
{
    public class SpecProcessAssignService : ISpecProcessAssignService
    {
        private ARMISContext Context;

        public SpecProcessAssignService(ARMISContext aContext)
        {
            Context = aContext;
        }

        //CREATE
        public async Task<SpecProcessAssignModel> PostSpecProcessAssign(SpecProcessAssignModel aSpecProcessASsignModel) //The model that gets passed in is returned with an updated SpecAssignId
        {
            int theNewSpecAssignId;
            var theCurrenSpecProcessAssigns = await Context.SpecProcessAssign.Where(i => i.SpecId == aSpecProcessASsignModel.SpecId && i.SpecRevId == aSpecProcessASsignModel.SpecRevId).ToListAsync();
            if (theCurrenSpecProcessAssigns != null && theCurrenSpecProcessAssigns.Any()) { theNewSpecAssignId = (theCurrenSpecProcessAssigns.OrderByDescending(i => i.SpecAssignId).FirstOrDefault().SpecAssignId)++; }
            else { theNewSpecAssignId = 1; }
            aSpecProcessASsignModel.SpecAssignId = theNewSpecAssignId;
            var theSpecProcessAssignEntity = aSpecProcessASsignModel.ToEntity();
            Context.SpecProcessAssign.Add(theSpecProcessAssignEntity);
            await Context.SaveChangesAsync();

            return aSpecProcessASsignModel;
        }

        //READ

        public async Task<IEnumerable<SpecProcessAssignModel>> GetAllHydratedSpecProcessAssign()
        {

            var theSpecProcessAssignEntities = await Context.SpecProcessAssign.Include(i => i.SpecChoiceNavigation)
                                                                              .Include(i => i.SpecChoice)
                                                                              .Include(i => i.SpecChoice1)
                                                                              .Include(i => i.SpecChoice2)
                                                                              .Include(i => i.SpecChoice3)
                                                                              .Include(i => i.SpecChoice4)
                                                                              .Include(i => i.PreBakeOptionNavigation.StepCategory)
                                                                              .Include(i => i.PostBakeOptionNavigation.StepCategory)
                                                                              .Include(i => i.MaskOptionNavigation.StepCategory)
                                                                              .Include(i => i.HardnessOptionNavigation)
                                                                              .Include(i => i.SeriesOptionNavigation)
                                                                              .Include(i => i.AlloyOptionNavigation)
                                                                              .Include(i => i.CustomerNavigation)
                                                                              .Include(i => i.Process)
                                                                              .ToListAsync();

            if (theSpecProcessAssignEntities == null || !theSpecProcessAssignEntities.Any()) { throw new Exception("No Process-Spec Assignments returned."); }

            return theSpecProcessAssignEntities.ToHydratedModels();
        }

        public async Task<SpecProcessAssignModel> GetSpecProcessAssign(int aSpecId, short aSpecRevId, short aSpecAssignId)
        {
            var theSpecProcesAssignEntity = await Context.SpecProcessAssign.FirstOrDefaultAsync(i => i.SpecId == aSpecId && i.SpecRevId == aSpecRevId && i.SpecAssignId == aSpecAssignId);

            if (theSpecProcesAssignEntity == null) { throw new Exception("No Spec Process Assignment was found."); }

            return theSpecProcesAssignEntity.ToModel();
        }
    }
}
