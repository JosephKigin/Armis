using Armis.BusinessModels.PartModels;
using ArmisWebsite.DataAccess.Quality.Interfaces;
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
        public MaterialSeriesDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task<IEnumerable<MaterialSeriesModel>> GetAllMaterialSeries()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<MaterialSeriesModel>>(Config["APIAddress"] + "api/MaterialSeries/GetAllMaterialSeries");
        }
    }
}
