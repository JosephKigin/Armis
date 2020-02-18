﻿using Armis.BusinessModels.ProcessModels;
using ArmisWebsite.DataAccess.Process.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace ArmisWebsite.DataAccess.Process
{
    public class ProcessDataAccess : IProcessDataAccess
    {
        private readonly IConfiguration Config;
        public ProcessDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task<IEnumerable<ProcessModel>> GetAllProcesses()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(Config["APIAddress"] + "api/Processes/GetHydratedProcesses");

                    var responseString = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<List<ProcessModel>>(responseString);

                    return result;
                }
                catch (Exception ex)
                {
                    throw; //TODO: Implement better error handling
                }
            }
        }

        public async Task<IEnumerable<ProcessModel>> GetAllHydratedProcesses()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(Config["APIAddress"] + "api/Processes/GetHydratedProcesses");

                    var responseString = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<List<ProcessModel>>(responseString);

                    return result;
                }
                catch (Exception ex)
                {
                    throw; //TODO: Implement better error handling on this whole page
                }
            }
        }

        public async Task<bool> CheckIfNameIsUnique(string aName)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(Config["APIAddress"] + "api/Processes/CheckIfNameIsUnique/" + aName);

                    var responseString = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<bool>(responseString);

                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

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
                    return "Something went wrong.";
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
    }
}