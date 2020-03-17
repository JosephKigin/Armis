using Armis.BusinessModels.ProcessModels;
using ArmisWebsite.DataAccess;
using ArmisWebsite.DataAccess.Process.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Process
{
    public class OperationDataAccess : IOperationDataAccess
    {
        private readonly IConfiguration Config;
        public OperationDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task<IEnumerable<OperationModel>> GetAllOperations()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<OperationModel>>(Config["APIAddress"] + "api/operation/getalloperations");
        }

        public async Task<IEnumerable<OperationGroupModel>> GetAllOperationGroups()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<OperationGroupModel>>(Config["APIAddress"] + "api/operation/GetAllOperationGroups");
        }

        public async Task<OperationModel> CreateOperation(OperationModel anOperationModel)
        {
            return await DataAccessGeneric.HttpPostRequest<OperationModel>(Config["APIAddress"] + "api/operation/CreateOperation", anOperationModel);
        }

        public async Task<OperationModel> UpdateOperation(OperationModel anOperationModel)
        {
            return await DataAccessGeneric.HttpPutRequest<OperationModel>(Config["APIAddress"] + "api/operation/UpdateOperation", anOperationModel);
        }
    }
}