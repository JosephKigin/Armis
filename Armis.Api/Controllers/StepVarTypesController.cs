using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Armis.Data.DatabaseContext;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.Services.ProcessServices.Interfaces;
using Armis.DataLogic.Services.ProcessServices;
using Armis.BusinessModels.ProcessModels;

namespace Armis.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepVarTypesController : ControllerBase
    {
        private readonly ARMISContext _context;

        private IVariableTypeService _variableTypeService;

        public IVariableTypeService VariableTypeService
        {
            get 
            {
                if(_variableTypeService == null) { _variableTypeService = new VariableTypeService(_context); }
                return _variableTypeService; 
            }
            set { _variableTypeService = value; }
        }


        public StepVarTypesController(ARMISContext context)
        {
            _context = context;
        }

        // GET: api/StepVarTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StepVarType>>> GetAllStepVarType()
        {
            try 
            { 
                var data = await VariableTypeService.GetAllVariableTypes();
                return Ok(JsonSerializer.Serialize(data));
            }
            catch(Exception ex) { return BadRequest(ex.Message); } //TODO: Error handling... This Should work
        }

        // GET: api/StepVarTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StepVarType>> GetStepVarType(string id)
        {
            var stepVarType = await _context.StepVarType.FindAsync(id);

            if (stepVarType == null)
            {
                return NotFound();
            }

            return stepVarType;
        }

        // PUT: api/StepVarTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStepVarType(string id, StepVarType stepVarType)
        {
            if (id != stepVarType.StepVarTypeCd)
            {
                return BadRequest();
            }

            _context.Entry(stepVarType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StepVarTypeExists(id))
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

        // POST: api/StepVarTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<StepVarType>> PostStepVarType(StepVarType stepVarType)
        {
            _context.StepVarType.Add(stepVarType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StepVarTypeExists(stepVarType.StepVarTypeCd))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStepVarType", new { id = stepVarType.StepVarTypeCd }, stepVarType);
        }

        // DELETE: api/StepVarTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StepVarType>> DeleteStepVarType(string id)
        {
            var stepVarType = await _context.StepVarType.FindAsync(id);
            if (stepVarType == null)
            {
                return NotFound();
            }

            _context.StepVarType.Remove(stepVarType);
            await _context.SaveChangesAsync();

            return stepVarType;
        }

        private bool StepVarTypeExists(string id)
        {
            return _context.StepVarType.Any(e => e.StepVarTypeCd == id);
        }
    }
}
