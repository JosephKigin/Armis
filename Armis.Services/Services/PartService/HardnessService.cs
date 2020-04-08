﻿using Armis.BusinessModels.PartModels;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.PartExtensions;
using Armis.DataLogic.Services.PartService.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.PartService
{
    class HardnessService : IHardnessService
    {
        private ARMISContext Context;

        public HardnessService(ARMISContext aContext)
        {
            Context = aContext;
        }
        public async Task<HardnessModel> GetHardness(int aHardnessId)
        {
            var theHardnessEntity = await Context.Hardness.FindAsync(aHardnessId);

            if(theHardnessEntity == null) { throw new Exception("No hardness was found."); }

            return theHardnessEntity.ToModel();
        }
    }
}