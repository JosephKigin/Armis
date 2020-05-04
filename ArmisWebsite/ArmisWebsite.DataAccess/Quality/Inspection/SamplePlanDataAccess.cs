using Armis.BusinessModels.QualityModels.Spec;
using ArmisWebsite.DataAccess.Quality.Inspection.Interfaces;
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

        public SamplePlanDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task<SamplePlanModel> CreateNewSamplePlan(SamplePlanModel aSamplePlanModel)
        {
            return await DataAccessGeneric.HttpPostRequest<SamplePlanModel>(Config["APIAddress"] + "api/SamplePlan/CreateHydratedSamplePlan/", aSamplePlanModel);
        }
    }
}
