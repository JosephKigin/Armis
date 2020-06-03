using Armis.BusinessModels.ShippingModels;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.ShippingExtensions;
using Armis.DataLogic.Services.ShippingService.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ShippingService
{
    public class PackageCodeService : IPackagCodeService
    {
        private ARMISContext Context;

        public PackageCodeService(ARMISContext aContext)
        {
            Context = aContext;
        }

        public async Task<IEnumerable<PackageCodeModel>> GetAllPackageCodes()
        {
            var entities = await Context.PackageCode.ToListAsync();

            if(entities == null || !entities.Any()) { throw new Exception("No Package Codes were returned"); }

            return entities.ToModels();
        }
    }
}
