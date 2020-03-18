using Armis.BusinessModels.ProcessModels;
using ArmisWebsite.DataAccess.Process.Interfaces;
using ArmisWebsite.DataAccess;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Process
{
    public class StepDataAccess : IStepDataAccess
    {
        private readonly IConfiguration Config;

        public StepDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task<StepModel> PostNewStep(StepModel aStepModel)
        {
            return await DataAccessGeneric.HttpPostRequest<StepModel>(Config["APIAddress"] + "api/Steps/PostStep/", aStepModel);
        }

        public async Task<IEnumerable<StepModel>> GetAllSteps()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<StepModel>>(Config["APIAddress"] + "api/Steps/GetAllSteps");
        }

        public async Task<IEnumerable<StepCategoryModel>> GetAllStepCategoryies()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<StepCategoryModel>>(Config["APIAddress"] + "api/Steps/GetAllStepCategories");
        }

        public async Task<StepCategoryModel> GetStepCategoryByCode(string aStepCategoryCode)
        {
            return await DataAccessGeneric.HttpGetRequest<StepCategoryModel>(Config["APIAddress"] + "api/Steps/GetStepCategoryByCode/" + aStepCategoryCode);
        }

        public async Task<StepModel> GetStepById(int aStepId)
        {
            return await DataAccessGeneric.HttpGetRequest<StepModel>(Config["APIAddress"] + "api/Steps/GetStepById/" + aStepId);
        }

        public async Task<List<StepModel>> GetStepByName(string aStepName)
        {
            return await DataAccessGeneric.HttpGetRequest<List<StepModel>>(Config["APIAddress"] + "api/Steps/GetStepByName/" + aStepName);
        }
    }
}
