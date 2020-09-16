using Armis.BusinessModels.ARModels;
using ArmisWebsite.DataAccess.AR.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.AR
{
    public class CertificationChargeDataAccess : ICertificationChargeDataAccess
    {
        private IConfiguration Config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CertificationChargeDataAccess(IConfiguration aConfig, IHttpContextAccessor anHttpContextAccessor)
        {
            Config = aConfig;
            _httpContextAccessor = anHttpContextAccessor;
        }

        public async Task<IEnumerable<CertificationChargeModel>> GetAllCertCharges()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<CertificationChargeModel>>(Config["APIAddress"] + "api/CertificationCharges/GetAllCertCharges", _httpContextAccessor.HttpContext);
        }
    }
}