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
using Armis.DataLogic.Services.ProcessServices.Interfaces;
using Armis.DataLogic.Services.ProcessServices;
using Armis.BusinessModels.ProcessModels;
using Armis.BusinessModels.ProcessModels.PassBackModels;

namespace Armis.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProcessesController : ControllerBase
    {
        private readonly ARMISContext _context;

        public IProcessService ProcessService { get; set; }

        public ProcessesController(ARMISContext context,
                                   IProcessService aProcessService)
        {
            _context = context;
            ProcessService = aProcessService;
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
            catch (Exception)
            {
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
                return BadRequest("Something went wrong, please contact IT. " + ex.Message);
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
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")] //This requires a PROCESS id to be sent in.
        public async Task<ActionResult<ProcessRevisionModel>> GetHydratedProcessRevision(int id)
        {
            try
            {
                var data = await ProcessService.GetCurrentProcessRevWithSteps(id);
                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {

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

                return BadRequest("Something went wrong.");
            }
        }

        // PUT: api/Processes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcess(int id, Process process)
        {
            if (id != process.ProcessId)
            {
                return BadRequest();
            }

            _context.Entry(process).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcessExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
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
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
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
                return BadRequest(ex.Message);                
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProcessRevisionModel>> UpdateStepsToRev(IEnumerable<StepSeqModel> aStepSeqModels)
        {
            try
            {
                var data = await ProcessService.UpdateStepsForRev(aStepSeqModels);
                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
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

                return BadRequest(ex.Message);
            }
        }

        private bool ProcessExists(int id)
        {
            return _context.Process.Any(e => e.ProcessId == id);
        }
    }
}
