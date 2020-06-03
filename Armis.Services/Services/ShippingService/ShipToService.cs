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
    public class ShipToService : IShipToService
    {
        private ARMISContext Context;

        public ShipToService(ARMISContext aContext)
        {
            Context = aContext;
        }

        public async Task<IEnumerable<ShipToModel>> GetAllShipToByCust(int aCustomerId)
        {
            var entities = await Context.ShipTo.Where(i => i.CustId == aCustomerId).Include(i => i.DefaultShipVia).ThenInclude(i => i.Carrier).ToListAsync();

            if(entities == null || !entities.Any()) { throw new Exception("Could not find any Ship Tos for that customer"); }

            return entities.ToModels();
        }
    }
}
