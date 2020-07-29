using Armis.BusinessModels.ShippingModels;
using ArmisWebsite.DataAccess.Shipping.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Shipping
{
    public class ShipViaCodeDataAccess : IShipViaCodeDataAccess
    {
        private IConfiguration Config;

        public ShipViaCodeDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task<IEnumerable<ShipViaCodeModel>> GetAllShipVias()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<ShipViaCodeModel>>(Config["APIAddress"] + "api/ShipViaCode/GetAllShipVias");
        }
    }
}
