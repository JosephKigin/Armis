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
    public class HardnessDataAccess : IHardnessDataAccess
    {
        private IConfiguration Config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HardnessDataAccess(IConfiguration aConfig, IHttpContextAccessor aHttpContextAccessor)
        {
            Config = aConfig;
            _httpContextAccessor = aHttpContextAccessor;
        }

        public async Task<IEnumerable<HardnessModel>> GetAllHardnesses()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<HardnessModel>>(Config["APIAddress"] + "api/Hardness/GetAllHardnesses", _httpContextAccessor.HttpContext);
        }

        public async Task<HardnessModel> CreateHardness(HardnessModel aHardnessModel)
        {
            return await DataAccessGeneric.HttpPostRequest<HardnessModel>(Config["APIAddress"] + "api/Hardness/CreateHardness", aHardnessModel, _httpContextAccessor.HttpContext);
        }
    }
}
