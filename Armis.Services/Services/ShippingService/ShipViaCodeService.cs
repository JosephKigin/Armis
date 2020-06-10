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
    public class ShipViaCodeService : IShipViaCodeService
    {
        private ARMISContext Context;

        public ShipViaCodeService(ARMISContext aContext)
        {
            Context = aContext;
        }

        public async Task<IEnumerable<ShipViaCodeModel>> GetAllShipVias()
        {
            var entities = await Context.ShipViaCode.Include(i => i.Carrier).ToListAsync();

            if (entities == null || !entities.Any()) { throw new Exception("No Ship Via Codes were returned"); }

            return entities.ToHydratedModels();
        }
    }
}
