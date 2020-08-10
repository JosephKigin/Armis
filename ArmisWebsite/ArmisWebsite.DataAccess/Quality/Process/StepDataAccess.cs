using Armis.BusinessModels.QualityModels.Process;
using ArmisWebsite.DataAccess.Quality.Interfaces;
using ArmisWebsite.DataAccess;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ArmisWebsite.DataAccess.Quality
{
    public class StepDataAccess : IStepDataAccess
    {
        private readonly IConfiguration Config;
        private readonly IHttpContextAccessor _httpContextAccessor; 

        public StepDataAccess(IConfiguration aConfig, IHttpContextAccessor aHttpContextAccessor)
        {
            Config = aConfig;
            _httpContextAccessor = aHttpContextAccessor;
        }

        public async Task<StepModel> PostNewStep(StepModel aStepModel)
        {
            return await DataAccessGeneric.HttpPostRequest<StepModel>(Config["APIAddress"] + "api/Steps/PostStep/", aStepModel, _httpContextAccessor.HttpContext);
        }

        public async Task<IEnumerable<StepModel>> GetAllSteps()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<StepModel>>(Config["APIAddress"] + "api/Steps/GetAllSteps", _httpContextAccessor.HttpContext);
        }

        public async Task<IEnumerable<StepModel>> GetAllStepsByCategory(string aCategoryCode)
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<StepModel>>(Config["APIAddress"] + "api/Steps/GetAllStepsByCategory/" + aCategoryCode, _httpContextAccessor.HttpContext);
        }

        public async Task<IEnumerable<StepCategoryModel>> GetAllStepCategoryies()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<StepCategoryModel>>(Config["APIAddress"] + "api/Steps/GetAllStepCategories", _httpContextAccessor.HttpContext);
        }

        public async Task<StepCategoryModel> GetStepCategoryById(short aStepCategoryId)
        {
            return await DataAccessGeneric.HttpGetRequest<StepCategoryModel>(Config["APIAddress"] + "api/Steps/GetStepCategoryById/" + aStepCategoryId, _httpContextAccessor.HttpContext);
        }

        public async Task<StepModel> GetStepById(int aStepId)
        {
            return await DataAccessGeneric.HttpGetRequest<StepModel>(Config["APIAddress"] + "api/Steps/GetStepById/" + aStepId, _httpContextAccessor.HttpContext);
        }

        public async Task<List<StepModel>> GetStepByName(string aStepName)
        {
            return await DataAccessGeneric.HttpGetRequest<List<StepModel>>(Config["APIAddress"] + "api/Steps/GetStepByName/" + aStepName, _httpContextAccessor.HttpContext);
        }
    }
}
