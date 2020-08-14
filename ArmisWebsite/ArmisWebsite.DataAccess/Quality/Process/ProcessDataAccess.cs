using Armis.BusinessModels.QualityModels.Process;
using ArmisWebsite.DataAccess;
using ArmisWebsite.DataAccess.Quality.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Armis.BusinessModels.QualityModels.PassBackModels;
using Microsoft.AspNetCore.Http;

namespace ArmisWebsite.DataAccess.Quality
{
    public class ProcessDataAccess : IProcessDataAccess
    {
        private readonly IConfiguration Config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProcessDataAccess(IConfiguration aConfig, IHttpContextAccessor aHttpContextAccessor)
        {
            Config = aConfig;
            _httpContextAccessor = aHttpContextAccessor;
        }
        //CREATE
        public async Task<ProcessModel> PostNewProcess(ProcessModel aProcessModel)
        {
            return await DataAccessGeneric.HttpPostRequest<ProcessModel>(Config["APIAddress"] + "api/processes/postprocess", aProcessModel, _httpContextAccessor.HttpContext);
        }

        public async Task<ProcessRevisionModel> RevUp(ProcessRevisionModel aProcessRevModel)
        {
            return await DataAccessGeneric.HttpPostRequest<ProcessRevisionModel>(Config["APIAddress"] + "api/processes/PostNewRev", aProcessRevModel, _httpContextAccessor.HttpContext);
        }

        //Since each step seq model has the revisionId and processId already in it, there is no need to pass that information in.
        public async Task<ProcessRevisionModel> SaveStepSeqToRevision(List<StepSeqModel> aProcessRevModel)
        {
            return await DataAccessGeneric.HttpPostRequest<ProcessRevisionModel, List<StepSeqModel>>(Config["APIAddress"] + "api/processes/UpdateStepsForRev", aProcessRevModel, _httpContextAccessor.HttpContext);
        }

        public async Task<ProcessModel> CopyToNewProcessFromExisting(ProcessModel aProcessModel)
        {
            return await DataAccessGeneric.HttpPostRequest<ProcessModel>(Config["APIAddress"] + "api/Processes/CopyNewProcessFromExisting", aProcessModel, _httpContextAccessor.HttpContext);
        }

        //READ
        public async Task<IEnumerable<ProcessModel>> GetAllHydratedProcesses()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<ProcessModel>>(Config["APIAddress"] + "api/Processes/GetHydratedProcesses", _httpContextAccessor.HttpContext);
        }

        public async Task<ProcessModel> GetHydratedProcess(int id)
        {
            return await DataAccessGeneric.HttpGetRequest<ProcessModel>(Config["APIAddress"] + "api/Processes/GetProcess/" + id, _httpContextAccessor.HttpContext);
        }

        public async Task<IEnumerable<ProcessModel>> GetHydratedProcessesWithCurrentLockedRev()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<ProcessModel>>(Config["APIAddress"] + "api/Processes/GetHydratedProcessesWithCurrentLockedRev", _httpContextAccessor.HttpContext);
        }

        public async Task<IEnumerable<ProcessModel>> GetHydratedProcessesWithCurrentAnyRev()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<ProcessModel>>(Config["APIAddress"] + "api/Processes/GetHydratedProcessesWithCurrentAnyRev", _httpContextAccessor.HttpContext);
        }

        public async Task<ProcessRevisionModel> GetHydratedCurrentProcessRev(int aProcessId)
        {
            return await DataAccessGeneric.HttpGetRequest<ProcessRevisionModel>(Config["APIAddress"] + "api/Processes/GetHydratedProcessRevision/" + aProcessId, _httpContextAccessor.HttpContext);
        }

    //UPDATE
    public async Task<ProcessRevisionModel> LockRevision(PassBackProcessRevStepSeqModel aPassBackModel)
        {
            return await DataAccessGeneric.HttpPostRequest<ProcessRevisionModel, PassBackProcessRevStepSeqModel>(Config["APIAddress"] + "api/processes/UpdateRevSaveAndLock/", aPassBackModel, _httpContextAccessor.HttpContext);
        }

        //DELETE
        public async Task<string> DeleteProcessRevision(int aProcessId, int aProcessRevId) //This will return the response from the API in string format.
        {
            return await DataAccessGeneric.HttpDeleteRequest(Config["APIAddress"] + "api/processes/DeleteProcessRevision/" + aProcessId + "/" + aProcessRevId, _httpContextAccessor.HttpContext);
        }
    }
}