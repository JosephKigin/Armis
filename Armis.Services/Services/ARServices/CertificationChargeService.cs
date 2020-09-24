using Armis.BusinessModels.ARModels;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.ARExtensions;
using Armis.DataLogic.Services.ARServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ARServices
{
    public class CertificationChargeService : ICertificationChargeService
    {
        private ARMISContext Context;

        public CertificationChargeService(ARMISContext aContext)
        {
            Context = aContext;
        }

        public async Task<IEnumerable<CertificationChargeModel>> GetAllCertCharges()
        {
            var entities = await Context.CertificationCharge.ToListAsync();

            if(entities == null || entities.Count < 1) { throw new Exception("No Certification Charges were returned."); }

            return entities.ToModels();
        }
    }
}
