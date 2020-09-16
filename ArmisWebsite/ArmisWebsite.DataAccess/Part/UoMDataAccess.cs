using Armis.BusinessModels.PartModels;
using ArmisWebsite.DataAccess.Part.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Part
{
    public class UoMDataAccess : IUoMDataAccess
    {
        private IConfiguration Config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UoMDataAccess(IConfiguration aConfig, IHttpContextAccessor aHttpContextAccessor)
        {
            Config = aConfig;
            _httpContextAccessor = aHttpContextAccessor;
        }

        public async Task<IEnumerable<UnitOfMeasureModel>> GetAllUoMs()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<UnitOfMeasureModel>>(Config["APIAddress"] + "api/UnitOfMeasure/GetAllUoMs", _httpContextAccessor.HttpContext);
        }
    }
}
