using Armis.BusinessModels.QualityModels.InspectionModels;
using Armis.BusinessModels.QualityModels.Spec;
using ArmisWebsite.DataAccess.Quality.Inspection.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Quality.Inspection
{
    public class TestTypeDataAccess : ITestTypeDataAccess
    {
        private readonly IConfiguration Config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TestTypeDataAccess(IConfiguration aConfig, IHttpContextAccessor aHttpContextAccessor)
        {
            Config = aConfig;
            _httpContextAccessor = aHttpContextAccessor;
        }

        public async Task<IEnumerable<InspectTestTypeModel>> GetAllTestTypes()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<InspectTestTypeModel>>(Config["APIAddress"] + "api/InspectTestType/GetAllTestTypes", _httpContextAccessor.HttpContext);
        }
    }
}
