using Armis.BusinessModels.QualityModels.InspectionModels;
using Armis.BusinessModels.QualityModels.Spec;
using ArmisWebsite.DataAccess.Quality.Inspection.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Quality.Inspection
{
    public class SamplePlanDataAccess : ISamplePlanDataAccess
    {
        private readonly IConfiguration Config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SamplePlanDataAccess(IConfiguration aConfig, IHttpContextAccessor aHttpContextAccessor)
        {
            Config = aConfig;
            _httpContextAccessor = aHttpContextAccessor;
        }

        public async Task<SamplePlanModel> CreateNewSamplePlan(SamplePlanModel aSamplePlanModel)
        {
            return await DataAccessGeneric.HttpPostRequest<SamplePlanModel>(Config["APIAddress"] + "api/SamplePlan/CreateHydratedSamplePlan/", aSamplePlanModel, _httpContextAccessor.HttpContext);
        }

        public async Task<IEnumerable<SamplePlanModel>> GetAllHydratedSamplePlans()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<SamplePlanModel>>(Config["APIAddress"] + "api/SamplePlan/GetAllHydratedSamplePlans", _httpContextAccessor.HttpContext);
        }
        public async Task<bool> CheckIfNameIsUnique(string aName)
        {
            return await DataAccessGeneric.HttpGetRequest<bool>(Config["APIAddress"] + "api/SamplePlan/CheckIfNameIsUnique/" + aName, _httpContextAccessor.HttpContext);
        }
    }
}
