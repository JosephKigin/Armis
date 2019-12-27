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
using Armis.DataLogic.Services.ProcessServices;
using Armis.DataLogic.Services.ProcessServices.Interfaces;
using Armis.BusinessModels.ProcessModels;

namespace Armis.Api.Controllers
{
    [Route("api/StepVarTemplates")]
    [ApiController]
    public class StepVarTemplatesController : ControllerBase
    {
        private readonly ARMISContext _context;
        private IVariableService _varService;
        public IVariableService VariableService 
        {
            get 
            {
                if(_varService == null) { _varService = new VariableService(_context); } 
                return _varService; 
            }
            set { _varService = value; } 
        }

        public StepVarTemplatesController(ARMISContext context)
        {
            _context = context;
        }

        // GET: api/StepVarTemplates
        [HttpGet("GetAllStepVarTemplates")]
        public async Task<ActionResult<IEnumerable<StepVarTemplate>>> GetAllStepVarTemplates()
        {
            try
            {
                var data = await VariableService.GetAllVariableTemplates();

                var jsonData = JsonSerializer.Serialize(data);

                return Ok(jsonData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/StepVarTemplates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StepVarTemplate>> GetStepVarTemplate(string aCode)
        {
            var stepVarTemplate = await _context.StepVarTemplate.FindAsync(aCode);

            if (stepVarTemplate == null)
            {
                return NotFound();
            }

            return stepVarTemplate;
        }

        // PUT: api/StepVarTemplates/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStepVarTemplate(string aCode, StepVarTemplate stepVarTemplate)
        {
            if (aCode != stepVarTemplate.VarTempCd)
            {
                return BadRequest();
            }

            _context.Entry(stepVarTemplate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StepVarTemplateExists(aCode))
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

        // POST: api/StepVarTemplates
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult> PostStepVarTemplate([FromBody]VariableTemplateModel aVariableTemplateModel)
        {
            try
            {
                await VariableService.PostVariableTemplate(aVariableTemplateModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); //TODO: Error handling
            }
        }

        // DELETE: api/StepVarTemplates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StepVarTemplate>> DeleteStepVarTemplate(int id)
        {
            var stepVarTemplate = await _context.StepVarTemplate.FindAsync(id);
            if (stepVarTemplate == null)
            {
                return NotFound();
            }

            _context.StepVarTemplate.Remove(stepVarTemplate);
            await _context.SaveChangesAsync();

            return stepVarTemplate;
        }

        private bool StepVarTemplateExists(string aCode)
        {
            return _context.StepVarTemplate.Any(e => e.VarTempCd == aCode);
        }
    }
}
