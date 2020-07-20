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

        public async Task<IEnumerable<SpecProcessAssignModel>> GetAllHydratedSpecProcessAssigns()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<SpecProcessAssignModel>>(Config["APIAddress"] + "api/SpecProcessAssign/GetAllHydratedSpecProcessAssign");
        }

        public async Task<IEnumerable<SpecProcessAssignModel>> GetAllActiveHydratedSpecProcessAssigns()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<SpecProcessAssignModel>>(Config["APIAddress"] + "api/SpecProcessAssign/GetAllActiveHydratedSpecProcessAssign");
        }

        public async Task<IEnumerable<SpecProcessAssignModel>> GetAllActiveHydratedSpecProcessAssignForSpec(int aSpecId)
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<SpecProcessAssignModel>>(Config["APIAddress"] + "api/SpecProcessAssign/GetAllActiveHydratedSpecProcessAssignForSpec/" + aSpecId);
        }

        public async Task<IEnumerable<SpecProcessAssignModel>> GetAllHydratedReviewNeededSpecProcessAssign()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<SpecProcessAssignModel>>(Config["APIAddress"] + "api/SpecProcessAssign/GetAllHydratedReviewNeededSpecProcessAssigns");
        }

        public async Task<SpecProcessAssignModel> PostSpecProcessAssign(SpecProcessAssignModel aSpecProcessAssign)
        {
            return await DataAccessGeneric.HttpPostRequest<SpecProcessAssignModel>(Config["APIAddress"] + "api/SpecProcessAssign/PostSpecProcessASsign/", aSpecProcessAssign);
        }

        public async Task<SpecProcessAssignModel> RemoveReviedNeeded(SpecProcessAssignModel aSpecProcessAssignModel)
        {
            return await DataAccessGeneric.HttpPostRequest<SpecProcessAssignModel>(Config["APIAddress"] + "api/SpecProcessAssign/RemoveReviewNeeded/", aSpecProcessAssignModel);
        }

        public async Task<SpecProcessAssignModel> CopyAfterReview(SpecProcessAssignModel aSpecProcessAssignModel)
        {
            return await DataAccessGeneric.HttpPostRequest<SpecProcessAssignModel>(Config["APIAddress"] + "api/SpecProcessAssign/CopyAfterReview", aSpecProcessAssignModel);
        }


        public async Task<bool> VerifyUniqueChoices(int specId, short internalSpecId, int? customer, IEnumerable<SpecProcessAssignOptionModel> anOptionModels)
        {
            return await DataAccessGeneric.HttpPostRequest<bool, IEnumerable<SpecProcessAssignOptionModel>>(Config["APIAddress"] + "api/SpecProcessAssign/VerifyUniqueChoices/" + specId + "/" + internalSpecId + "/" + customer, anOptionModels);
        }

        public async Task<bool> CheckIfReviewIsNeededForSpecId(int aSpecId)
        {
            return await DataAccessGeneric.HttpGetRequest<bool>(Config["APIAddress"] + "api/SpecProcessAssign/CheckIfReviewIsNeededForSpecId/" + aSpecId);
        }

        public async Task<bool> CheckSpaIsViable(int aSpecId, IEnumerable<SpecProcessAssignOptionModel> anOptionModels)
        {
            return await DataAccessGeneric.HttpPostRequest<bool, IEnumerable<SpecProcessAssignOptionModel>>(Config["APIAddress"] + "api/SpecProcessAssign/CheckSpaIsViable/" + aSpecId, anOptionModels);
        }
    }
}
