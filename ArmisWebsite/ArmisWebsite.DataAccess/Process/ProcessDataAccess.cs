using Armis.BusinessModels.ProcessModels;
using ArmisWebsite.DataAccess.Process.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Armis.BusinessModels.ProcessModels.PassBackModels;

namespace ArmisWebsite.DataAccess.Process
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
            using (var client = new HttpClient())
            {
                try
                {
                    StringContent data = new StringContent(JsonSerializer.Serialize(aProcessModel), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(Config["APIAddress"] + "api/processes/postprocess", data);

                    var responseString = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<ProcessModel>(responseString);

                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public async Task<ProcessRevisionModel> RevUp(ProcessRevisionModel aProcessRevModel)
        {
            using (var client = new HttpClient())
            {
                StringContent data = new StringContent(JsonSerializer.Serialize(aProcessRevModel), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Config["APIAddress"] + "api/processes/PostNewRev", data);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<ProcessRevisionModel>(responseString);

                    return result;
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }
        }

        //Since each step seq model has the revisionId and processId already in it, there is no need to pass that information in.
        public async Task<ProcessRevisionModel> SaveStepSeqToRevision(List<StepSeqModel> aStepSeqModel)
        {
            using (var client = new HttpClient())
            {
                StringContent data = new StringContent(JsonSerializer.Serialize(aStepSeqModel), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Config["APIAddress"] + "api/processes/UpdateStepsForRev", data);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<ProcessRevisionModel>(responseString);

                    return result;
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }
        }

        public async Task<ProcessModel> CopyToNewProcessFromExisting(ProcessModel aProcessModel)
        {
            using(var client = new HttpClient())
            {
                StringContent data = new StringContent(JsonSerializer.Serialize(aProcessModel), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(Config["APIAddress"] + "api/Processes/CopyNewProcessFromExisting", data);

                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ProcessModel>(responseString);

                return result;
            }
        }

        //READ
        public async Task<IEnumerable<ProcessModel>> GetAllHydratedProcesses()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(Config["APIAddress"] + "api/Processes/GetHydratedProcesses");

                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<ProcessModel>>(responseString);

                return result;
            }
        }

        public async Task<bool> CheckIfNameIsUnique(string aName) //TODO: Is this even being used anywhere?
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(Config["APIAddress"] + "api/Processes/CheckIfNameIsUnique/" + aName);

                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<bool>(responseString);

                return result;
            }

        }

        //UPDATE
        public async Task<ProcessRevisionModel> LockRevision(int aProcessId, int aProcessRevId, List<StepSeqModel> aStepList)
        {
            using (var client = new HttpClient())
            {
                var thePassBackModel = new PassBackProcessRevStepSeqModel
                {
                    ProcessId = aProcessId,
                    ProcessRevisionId = aProcessRevId,
                    StepSeqList = aStepList
                };

                StringContent data = new StringContent(JsonSerializer.Serialize(thePassBackModel), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Config["APIAddress"] + "api/processes/UpdateRevSaveAndLock/", data);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<ProcessRevisionModel>(responseString);

                    return result;
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }
        }

        //DELETE
        public async Task<string> DeleteProcessRevision(int aProcessId, int aProcessRevId) //This will return the response from the API in string format.
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync(Config["APIAddress"] + "api/processes/DeleteProcessRevision/" + aProcessId + "/" + aProcessRevId);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "Process deleted successfully.";
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }
        }
    }
}
