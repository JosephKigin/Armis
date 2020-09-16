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
    public class PackageCodeDataAccess : IPackageCodeDataAccess
    {
        private IConfiguration Config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PackageCodeDataAccess(IConfiguration aConfig, IHttpContextAccessor aHttpContextAccessor)
        {
            Config = aConfig;
            _httpContextAccessor = aHttpContextAccessor;
        }
        public async Task<IEnumerable<PackageCodeModel>> GetAllPackageCodes()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<PackageCodeModel>>(Config["APIAddress"] + "api/PackageCode/GetAllPackageCodes", _httpContextAccessor.HttpContext);
        }
    }
}
