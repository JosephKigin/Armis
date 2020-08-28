using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Armis.Data.DatabaseContext;
using Armis.Data.DatabaseContext.Entities;
using System.Text.Json;
using Armis.DataLogic.Services.QualityServices.Interfaces;
using Armis.DataLogic.Services.QualityServices;
using Armis.BusinessModels.QualityModels.Process;
using Armis.BusinessModels.QualityModels.PassBackModels;
using Microsoft.Extensions.Logging;

namespace Armis.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProcessesController : ControllerBase
    {
        private readonly ILogger<ProcessesController> _logger;

        public IProcessService ProcessService { get; set; }

        public ProcessesController(IProcessService aProcessService, ILogger<ProcessesController> aLogger)
        {
            ProcessService = aProcessService;
            _logger = aLogger;
        }

        // GET: api/Processes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcessModel>>> GetProcess()
        {
            try
            {
                var data = await ProcessService.GetAllProcesses();
                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("ProcessesController.GetProcess() Not able to get all processes. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest("Something went wrong, please contact IT.");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcessModel>>> GetHydratedProcesses()
        {
            try
            {
                var data = await ProcessService.GetHydratedProcessRevs();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("ProcessesController.GetHydratedProcesses() Not able to get all hydrated processes. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest("Something went wrong, please contact IT. " + ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcessModel>>> GetHydratedProcessesWithCurrentLockedRev() //This returns the most recent LOCKED rev
        {
            try
            {
                var data = await ProcessService.GetHydratedProcessesWithCurrentLockedRev();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("ProcessesController.GetHydratedProcessesWithCurrentLockedRev() Not able to get all hydrated processes with a current and locked revision. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcessModel>>> GetHydratedProcessesWithCurrentAnyRev()
        {
            try
            {
                var data = await ProcessService.GetHydratedProcessesWithCurrentAnyRev();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("ProcessesController.GetHydratedProcessesWithCurrentAnyRev() Not able to get all hydrated processes with current revisions. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Processes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProcessModel>> GetProcess(int id)
        {
            try
            {
                var process = await ProcessService.GetHydratedProcess(id);
                return Ok(JsonSerializer.Serialize(process));
            }
            catch (Exception ex)
            {
                _logger.LogError("ProcessesController.GetProcess(int id) Not able to get process with id {id}. | Message: {exMessage} | StackTrace: {stackTrace}", id, ex.Message, ex.StackTrace);
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")] //This requires a PROCESS id to be sent in.
        public async Task<ActionResult<ProcessRevisionModel>> GetProcessCurrentHydratedRev(int id)
        {
            try
            {
                var data = await ProcessService.GetProcessCurrentHydratedRev(id);
                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("ProcessesController.GetHydratedProcessRevision(int id) Not able to get process with id {id}. | Message: {exMessage} | StackTrace: {stackTrace}", id, ex.Message, ex.StackTrace);
                return NotFound(JsonSerializer.Serialize("ERROR: " + ex.Message));
            }
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<bool>> CheckIfNameIsUnique(string name)
        {
            try
            {
                var data = await ProcessService.CheckIfNameIsUnique(name);
                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("ProcessesController.CheckIfNameIsUnique(string name) Not able to check if process name({name}) is unique. | Message: {exMessage} | StackTrace: {stackTrace}", name, ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProcessModel>> PostProcess(ProcessModel aProcessModel)
        {
            try
            {
                var data = await ProcessService.CreateNewProcess(aProcessModel);
                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("ProcessesController.PostProcess(ProcessModel aProcessModel) Not able to create process {process}. | Message: {exMessage} | StackTrace: {stackTrace}", JsonSerializer.Serialize(aProcessModel), ex.Message, ex.StackTrace);
                return BadRequest("Could not process request. " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProcessRevisionModel>> PostNewRev(ProcessRevisionModel aProcessRevModel)
        {
            try
            {
                var data = await ProcessService.CreateNewRevForExistingProcess(aProcessRevModel);
                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("ProcessesController.PostNewRev(ProcessRevisionModel aProcessRevModel) Not able to create process revision {processRev}. | Message: {exMessage} | StackTrace: {stackTrace}", JsonSerializer.Serialize(aProcessRevModel), ex.Message, ex.StackTrace); 
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{aProcessId}/{aRevId}")]
        public async Task<ActionResult<ProcessRevisionModel>> UpdateRevToLocked(int aProcessId, int aRevId)
        {
            try
            {
                var data = await ProcessService.UpdateUnlockToLockRev(aProcessId, aRevId);
                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("ProcessesController.UpdateRevToLocked(int aProcessId, int aRevId) Not able to lock process revision. ProcessId: ({processId}) RevisionId: ({revisionId}) | Message: {exMessage} | StackTrace: {stackTrace}", aProcessId, aRevId, ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        //Only the step seq is needed from this Rev model parameter but the website can handle a post better when the return type is the same as the parameter type.
        [HttpPost]
        public async Task<ActionResult<ProcessRevisionModel>> UpdateStepsForRev(List<StepSeqModel> aStepSeqModels)
        {
            try
            {
                var data = await ProcessService.UpdateStepsForRev(aStepSeqModels);
                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("ProcessesController.UpdateStepsForRev(List<StepSeqModel> aRevModel) Not able to update steps for revision process revision. Steps: ({steps}) | Message: {exMessage} | StackTrace: {stackTrace}", JsonSerializer.Serialize(aStepSeqModels), ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        //Updates the rev steps and locks the rev
        public async Task<ActionResult<ProcessRevisionModel>> UpdateRevSaveAndLock(PassBackProcessRevStepSeqModel aRevStepSeqModel)
        {
            try
            {
                await ProcessService.UpdateStepsForRev(aRevStepSeqModel.StepSeqList);
                var data = await ProcessService.UpdateUnlockToLockRev(aRevStepSeqModel.ProcessId, aRevStepSeqModel.ProcessRevisionId);
                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("ProcessesController.UpdateRevSaveAndLock(PassBackProcessRevStepSeqModel aRevStepSeqModel) Not able to update rev to saved and locked. ProcessRev: ({rev}) | Message: {exMessage} | StackTrace: {stackTrace}", JsonSerializer.Serialize(aRevStepSeqModel), ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProcessModel>> CopyNewProcessFromExisting(ProcessModel aProcessModel)
        {
            try
            {
                var data = await ProcessService.CopyToNewProcessFromExisting(aProcessModel);
                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("ProcessesController.CopyNewProcessFromExisting(ProcessModel aProcessModel) Not able to copy to new process from existing. Process: ({process}) | Message: {exMessage} | StackTrace: {stackTrace}", JsonSerializer.Serialize(aProcessModel), ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{aProcessId}/{aProcessRevId}")]
        public async Task<ActionResult> DeleteProcessRevision(int aProcessId, int aProcessRevId)
        {
            try
            {
                await ProcessService.DeleteProcessRev(aProcessId, aProcessRevId);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("ProcessesController.DeleteProcessRevision(int aProcessId, int aProcessRevId) Not able to delete process rev. ProcessId: ({processId}) RevId({revId}) | Message: {exMessage} | StackTrace: {stackTrace}", aProcessId, aProcessRevId, ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}
