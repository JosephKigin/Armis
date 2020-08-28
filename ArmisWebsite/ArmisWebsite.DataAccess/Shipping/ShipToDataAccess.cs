using Armis.BusinessModels.ShippingModels;
using ArmisWebsite.DataAccess.Shipping.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Shipping
{
    public class ShipToDataAccess : IShipToDataAccess
    {
        private IConfiguration Config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShipToDataAccess(IConfiguration aConfig, IHttpContextAccessor aHttpContextAccessor)
        {
            Config = aConfig;
            _httpContextAccessor = aHttpContextAccessor;
        }
        public async Task<IEnumerable<ShipToModel>> GetShipToByCustId(int aCustId)
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<ShipToModel>>(Config["APIAddress"] + "api/ShipTo/GetShipTosByCust/" + aCustId, _httpContextAccessor.HttpContext);
        }
    }
}
