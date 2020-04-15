using Armis.BusinessModels.QualityModels;
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

namespace ArmisWebsite.DataAccess.Quality
{
    public class ProcessDataAccess : IProcessDataAccess
    {
        private readonly IConfiguration Config;
        public ProcessDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }
        //CREATE
        public async Task<ProcessModel> PostNewProcess(ProcessModel aProcessModel)
        {
            return await DataAccessGeneric.HttpPostRequest<ProcessModel>(Config["APIAddress"] + "api/processes/postprocess", aProcessModel);
        }

        public async Task<ProcessRevisionModel> RevUp(ProcessRevisionModel aProcessRevModel)
        {
            return await DataAccessGeneric.HttpPostRequest<ProcessRevisionModel>(Config["APIAddress"] + "api/processes/PostNewRev", aProcessRevModel);
        }

        //Since each step seq model has the revisionId and processId already in it, there is no need to pass that information in.
        public async Task<ProcessRevisionModel> SaveStepSeqToRevision(List<StepSeqModel> aProcessRevModel)
        {
            return await DataAccessGeneric.HttpPostRequest<ProcessRevisionModel, List<StepSeqModel>>(Config["APIAddress"] + "api/processes/UpdateStepsForRev", aProcessRevModel);
        }

        public async Task<ProcessModel> CopyToNewProcessFromExisting(ProcessModel aProcessModel)
        {
            return await DataAccessGeneric.HttpPostRequest<ProcessModel>(Config["APIAddress"] + "api/Processes/CopyNewProcessFromExisting", aProcessModel);
        }

        //READ
        public async Task<IEnumerable<ProcessModel>> GetAllHydratedProcesses()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<ProcessModel>>(Config["APIAddress"] + "api/Processes/GetHydratedProcesses");
        }

        public async Task<ProcessModel> GetHydratedProcess(int id)
        {
            return await DataAccessGeneric.HttpGetRequest<ProcessModel>(Config["APIAddress"] + "api/Processes/GetProcess/" + id);
        }

        public async Task<bool> CheckIfNameIsUnique(string aName) //TODO: Is this even being used anywhere? No it is not...
        {
            return await DataAccessGeneric.HttpGetRequest<bool>(Config["APIAddress"] + "api/Processes/CheckIfNameIsUnique/" + aName);
        }

        //UPDATE
        public async Task<ProcessRevisionModel> LockRevision(int aProcessId, int aProcessRevId, List<StepSeqModel> aStepList)
        {
            var thePassBackModel = new PassBackProcessRevStepSeqModel //TODO: should this be moved to the front-end?
            {
                ProcessId = aProcessId,
                ProcessRevisionId = aProcessRevId,
                StepSeqList = aStepList
            };

            return await DataAccessGeneric.HttpPostRequest<ProcessRevisionModel, PassBackProcessRevStepSeqModel>(Config["APIAddress"] + "api/processes/UpdateRevSaveAndLock/", thePassBackModel);
        }

        //DELETE
        public async Task<string> DeleteProcessRevision(int aProcessId, int aProcessRevId) //This will return the response from the API in string format.
        {
            return await DataAccessGeneric.HttpDeleteRequest(Config["APIAddress"] + "api/processes/DeleteProcessRevision/" + aProcessId + "/" + aProcessRevId);
        }
    }
}