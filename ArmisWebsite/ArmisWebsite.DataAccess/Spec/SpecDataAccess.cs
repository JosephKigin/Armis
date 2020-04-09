using Armis.BusinessModels.ProcessModels.Spec;
using ArmisWebsite.DataAccess.Process.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Process
{
    public class SpecDataAccess : ISpecDataAccess
    {
        private readonly IConfiguration Config;

        public SpecDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        //public async Task<IEnumerable<SpecModel>> GetAll

        public async Task<IEnumerable<SpecModel>> GetAllHydratedSpecs()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<SpecModel>>(Config["APIAddress"] + "api/spec/GetAllHydratedSpecs");
        }

        public async Task<IEnumerable<SpecModel>> GetAllHydratedSpecsWithOnlyCurrentRev()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<SpecModel>>(Config["APIAddress"] + "api/spec/GetAllHydratedSpecsWithOnlyCurrentRev");
        }

        public async Task<int> CreateNewHydratedSpec(SpecModel aSpecModel)
        {
            return await DataAccessGeneric.HttpPostRequest<int, SpecModel>(Config["APIAddress"] + "api/spec/CreateNewSpec", aSpecModel);
        }

        public async Task<SpecModel> GetHydratedCurrentRevOfSpec(int aSpecId)
        {
            return await DataAccessGeneric.HttpGetRequest<SpecModel>(Config["APIAddress"] + "api/spec/GetHydratedCurrentRevOfSpec/" + aSpecId);
        }

        public async Task<int> RevUpSpec(SpecRevModel aSpecModel)
        {
            return await DataAccessGeneric.HttpPostRequest<int, SpecRevModel>(Config["APIAddress"] + "api/Spec/RevUpSpec", aSpecModel);
        }
    }
}
