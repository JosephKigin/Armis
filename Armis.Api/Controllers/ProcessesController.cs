﻿using System;
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

                return NotFound(ex.Message);
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

        // POST: api/Processes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<Process>> PostProcess(Process process)
        //{
        //    _context.Process.Add(process);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ProcessExists(process.ProcessId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetProcess", new { id = process.ProcessId }, process);
        //}

        [HttpPost]
        public async Task TestPostProcess()
        {
            await ProcessService.TestCreateProcess();
        }

        // DELETE: api/Processes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Process>> DeleteProcess(int id)
        {
            var process = await _context.Process.FindAsync(id);
            if (process == null)
            {
                return NotFound();
            }

            _context.Process.Remove(process);
            await _context.SaveChangesAsync();

            return process;
        }

        private bool ProcessExists(int id)
        {
            return _context.Process.Any(e => e.ProcessId == id);
        }
    }
}
