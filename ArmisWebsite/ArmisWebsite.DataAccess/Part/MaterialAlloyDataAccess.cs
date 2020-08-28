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
    public class MaterialAlloyDataAccess : IMaterialAlloyDataAccess
    {
        private readonly IConfiguration Config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MaterialAlloyDataAccess(IConfiguration aConfig, IHttpContextAccessor aHttpContextAccessor)
        {
            Config = aConfig;
            _httpContextAccessor = aHttpContextAccessor;
        }

        public async Task<IEnumerable<MaterialAlloyModel>> GetAllMaterialAlloys()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<MaterialAlloyModel>>(Config["APIAddress"] + "api/MaterialAlloy/GetAllMaterialAlloys", _httpContextAccessor.HttpContext);
        }

        public async Task<MaterialAlloyModel> CreateMaterialAlloy(MaterialAlloyModel aMaterialAlloyModel)
        {
            return await DataAccessGeneric.HttpPostRequest<MaterialAlloyModel>(Config["APIAddress"] + "api/MaterialAlloy/CreateMaterialAlloy", aMaterialAlloyModel, _httpContextAccessor.HttpContext);
        }

        public async Task<bool> CheckIfDescriptionIsUnique(string anAlloyDescription)
        {
            return await DataAccessGeneric.HttpGetRequest<bool>(Config["APIAddress"] + "api/MaterialAlloy/CheckIfDescriptionIsUnique/" + anAlloyDescription,  _httpContextAccessor.HttpContext);
        }
    }
}
