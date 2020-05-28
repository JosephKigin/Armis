using Armis.BusinessModels.QualityModels.Spec;
using ArmisWebsite.DataAccess.Quality.Specification.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Quality.Specification
{
    public class SpecProcessAssignDataAccess : ISpecProcessAssignDataAccess
    {
        private IConfiguration Config;

        public SpecProcessAssignDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task<IEnumerable<SpecProcessAssignModel>> GetAllSpecProcessAssigns()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<SpecProcessAssignModel>>(Config["APIAddress"] + "api/SpecProcessAssign/GetAllHydratedSpecProcessAssign");
        }

        public async Task<SpecProcessAssignModel> PostSpecProcessAssign(SpecProcessAssignModel aSpecProcessAssign)
        {
            return await DataAccessGeneric.HttpPostRequest<SpecProcessAssignModel>(Config["APIAddress"] + "api/SpecProcessAssign/PostSpecProcessASsign/", aSpecProcessAssign);
        }

        public async Task<bool> VerifyUniqueChoices(int specId, short internalSpecId, int? choice1, int? choice2, int? choice3, int? choice4, int? choice5, int? choice6, int? preBake, int? postBake, int? mask, int? hardness, int? series, int? alloy, int? customer)
        {
            return await DataAccessGeneric.HttpGetRequest<bool>(Config["APIAddress"] + "api/SpecProcessAssign/VerifyUniqueChoices/" + specId + "/" + internalSpecId + "/" + choice1 + "/" + choice2 + "/" + choice3 + "/" + choice4 + "/" + choice5 + "/" + choice6 + "/" + preBake + "/" + postBake + "/" + mask + "/" + hardness + "/" + series + "/" + alloy + "/" + customer);
        }
    }
}
