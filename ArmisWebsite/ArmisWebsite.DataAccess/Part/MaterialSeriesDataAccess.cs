using Armis.BusinessModels.PartModels;
using ArmisWebsite.DataAccess.Quality.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Quality
{
    public class MaterialSeriesDataAccess : IMaterialSeriesDataAccess
    {
        private readonly IConfiguration Config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MaterialSeriesDataAccess(IConfiguration aConfig, IHttpContextAccessor aHttpContextAccessor)
        {
            Config = aConfig;
            _httpContextAccessor = aHttpContextAccessor;
        }

        public async Task<IEnumerable<MaterialSeriesModel>> GetAllMaterialSeries()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<MaterialSeriesModel>>(Config["APIAddress"] + "api/MaterialSeries/GetAllMaterialSeries", _httpContextAccessor.HttpContext);
        }

        public async Task<MaterialSeriesModel> CreateMaterialSeries(MaterialSeriesModel aMaterialSeriesModel)
        {
            return await DataAccessGeneric.HttpPostRequest<MaterialSeriesModel>(Config["APIAddress"] + "api/MaterialSeries/CreateMaterialSeries", aMaterialSeriesModel, _httpContextAccessor.HttpContext);
        }
    }
}
