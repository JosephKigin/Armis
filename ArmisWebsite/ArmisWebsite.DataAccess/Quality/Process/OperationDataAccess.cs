using Armis.BusinessModels.QualityModels.Process;
using ArmisWebsite.DataAccess;
using ArmisWebsite.DataAccess.Quality.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Quality
{
    public class OperationDataAccess : IOperationDataAccess
    {
        private readonly IConfiguration Config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OperationDataAccess(IConfiguration aConfig, IHttpContextAccessor aHttpContextAccessor)
        {
            Config = aConfig;
            _httpContextAccessor = aHttpContextAccessor;
        }

        public async Task<IEnumerable<OperationModel>> GetAllOperations()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<OperationModel>>(Config["APIAddress"] + "api/operation/getalloperations", _httpContextAccessor.HttpContext);
        }

        public async Task<IEnumerable<OperationGroupModel>> GetAllOperationGroups()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<OperationGroupModel>>(Config["APIAddress"] + "api/operation/GetAllOperationGroups", _httpContextAccessor.HttpContext);
        }

        public async Task<OperationModel> CreateOperation(OperationModel anOperationModel)
        {
            return await DataAccessGeneric.HttpPostRequest<OperationModel>(Config["APIAddress"] + "api/operation/CreateOperation", anOperationModel, _httpContextAccessor.HttpContext);
        }

        public async Task<OperationModel> UpdateOperation(OperationModel anOperationModel)
        {
            return await DataAccessGeneric.HttpPutRequest<OperationModel>(Config["APIAddress"] + "api/operation/UpdateOperation", anOperationModel, _httpContextAccessor.HttpContext);
        }
    }
}