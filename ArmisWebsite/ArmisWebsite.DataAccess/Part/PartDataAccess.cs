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
    public class PartDataAccess : IPartDataAccess
    {
        private IConfiguration Config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PartDataAccess(IConfiguration aConfig, IHttpContextAccessor aHttpContextAccessor)
        {
            Config = aConfig;
            _httpContextAccessor = aHttpContextAccessor;
        }

        public async Task<IEnumerable<PartModel>> GetAllParts()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<PartModel>>(Config["APIAddress"] + "api/Part/GetAllParts", _httpContextAccessor.HttpContext);
        }

        public async Task<IEnumerable<PartModel>> GetAllPartsWithRack()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<PartModel>>(Config["APIAddress"] + "api/Part/GetAllPartsWithRacks", _httpContextAccessor.HttpContext);
        }

        public async Task<IEnumerable<PartModel>> GetPartForCustId(int aCustId)
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<PartModel>>(Config["APIAddress"] + "api/Part/GetPartsForCustId/" + aCustId, _httpContextAccessor.HttpContext);
        }

        public async Task<PartModel> CreatePart(PartModel aPart)
        {
            return await DataAccessGeneric.HttpPostRequest<PartModel>(Config["APIAddress"] + "api/Part/CreatePart", aPart, _httpContextAccessor.HttpContext);
        }

    }
}
