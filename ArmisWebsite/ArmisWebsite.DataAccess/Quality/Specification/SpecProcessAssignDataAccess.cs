using Armis.BusinessModels.QualityModels.Spec;
using ArmisWebsite.DataAccess.Quality.Specification.Interfaces;
using Microsoft.AspNetCore.Http;
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
        private IHttpContextAccessor _httpContextAccessor;

        public SpecProcessAssignDataAccess(IConfiguration aConfig, IHttpContextAccessor aHttpContextAccessor)
        {
            Config = aConfig;
            _httpContextAccessor = aHttpContextAccessor;
        }

        public async Task<IEnumerable<SpecProcessAssignModel>> GetAllHydratedSpecProcessAssigns()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<SpecProcessAssignModel>>(Config["APIAddress"] + "api/SpecProcessAssign/GetAllHydratedSpecProcessAssign", _httpContextAccessor.HttpContext);
        }

        public async Task<IEnumerable<SpecProcessAssignModel>> GetAllActiveHydratedSpecProcessAssigns()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<SpecProcessAssignModel>>(Config["APIAddress"] + "api/SpecProcessAssign/GetAllActiveHydratedSpecProcessAssign", _httpContextAccessor.HttpContext);
        }

        public async Task<IEnumerable<SpecProcessAssignModel>> GetAllActiveHydratedSpecProcessAssignForSpec(int aSpecId)
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<SpecProcessAssignModel>>(Config["APIAddress"] + "api/SpecProcessAssign/GetAllActiveHydratedSpecProcessAssignForSpec/" + aSpecId, _httpContextAccessor.HttpContext);
        }

        public async Task<IEnumerable<SpecProcessAssignModel>> GetAllHydratedReviewNeededSpecProcessAssign()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<SpecProcessAssignModel>>(Config["APIAddress"] + "api/SpecProcessAssign/GetAllHydratedReviewNeededSpecProcessAssigns", _httpContextAccessor.HttpContext);
        }

        public async Task<IEnumerable<SpecProcessAssignModel>> GetHydratedHistorySpecProcessAssignsForSpec(int aSpecId)
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<SpecProcessAssignModel>>(Config["APIAddress"] + "api/SpecProcessAssign/GetHydratedHistorySpecProcessAssignForSpec/" + aSpecId, _httpContextAccessor.HttpContext);
        }

        public async Task<SpecProcessAssignModel> PostSpecProcessAssign(SpecProcessAssignModel aSpecProcessAssign)
        {
            return await DataAccessGeneric.HttpPostRequest<SpecProcessAssignModel>(Config["APIAddress"] + "api/SpecProcessAssign/PostSpecProcessASsign/", aSpecProcessAssign, _httpContextAccessor.HttpContext);
        }

        public async Task<SpecProcessAssignModel> RemoveReviedNeeded(SpecProcessAssignModel aSpecProcessAssignModel)
        {
            return await DataAccessGeneric.HttpPostRequest<SpecProcessAssignModel>(Config["APIAddress"] + "api/SpecProcessAssign/RemoveReviewNeeded/", aSpecProcessAssignModel, _httpContextAccessor.HttpContext);
        }

        public async Task<SpecProcessAssignModel> CopyAfterReview(SpecProcessAssignModel aSpecProcessAssignModel)
        {
            return await DataAccessGeneric.HttpPostRequest<SpecProcessAssignModel>(Config["APIAddress"] + "api/SpecProcessAssign/CopyAfterReview", aSpecProcessAssignModel, _httpContextAccessor.HttpContext);
        }


        public async Task<bool> VerifyUniqueChoices(int specId, short internalSpecId, int? customer, IEnumerable<SpecProcessAssignOptionModel> anOptionModels)
        {
            return await DataAccessGeneric.HttpPostRequest<bool, IEnumerable<SpecProcessAssignOptionModel>>(Config["APIAddress"] + "api/SpecProcessAssign/VerifyUniqueChoices/" + specId + "/" + internalSpecId + "/" + customer, anOptionModels, _httpContextAccessor.HttpContext);
        }

        public async Task<bool> CheckIfReviewIsNeededForSpecId(int aSpecId)
        {
            return await DataAccessGeneric.HttpGetRequest<bool>(Config["APIAddress"] + "api/SpecProcessAssign/CheckIfReviewIsNeededForSpecId/" + aSpecId, _httpContextAccessor.HttpContext);
        }

        public async Task<bool> CheckSpaIsViable(int aSpecId, IEnumerable<SpecProcessAssignOptionModel> anOptionModels)
        {
            return await DataAccessGeneric.HttpPostRequest<bool, IEnumerable<SpecProcessAssignOptionModel>>(Config["APIAddress"] + "api/SpecProcessAssign/CheckSpaIsViable/" + aSpecId, anOptionModels, _httpContextAccessor.HttpContext);
        }
    }
}
