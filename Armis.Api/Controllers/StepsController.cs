using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Armis.Data.DatabaseContext;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.ProcessServices.Interfaces;
using Armis.DataLogic.Services.ProcessServices;
using Armis.BusinessModels.ProcessModels;
using System.Text.Json;

namespace Armis.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepsController : ControllerBase
    {
        private readonly ARMISContext _context;

        private IStepService _stepService;

        public IStepService StepService
        {
            get 
            {
                if(_stepService == null) { _stepService = new StepService(_context); }
                return _stepService; 
            }
            set { _stepService = value; }
        }


        public StepsController(ARMISContext context)
        {
            _context = context;
        }

        // GET: api/Steps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Step>>> GetAllHydratedSteps()
        {
            try
            {
                var data = await StepService.GetAll();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        // GET: api/Steps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Step>> GetStep(int id)
        {
            var step = await _context.Step.FindAsync(id);

            if (step == null)
            {
                return NotFound();
            }

            return step;
        }

        // PUT: api/Steps/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStep(int id, Step step)
        {
            if (id != step.StepId)
            {
                return BadRequest();
            }

            _context.Entry(step).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StepExists(id))
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

        // POST: api/Steps
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Step>> PostStep(StepModel aStep)
        {
            try
            {
                await StepService.CreateStep(aStep);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Steps/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Step>> DeleteStep(int id)
        {
            var step = await _context.Step.FindAsync(id);
            if (step == null)
            {
                return NotFound();
            }

            _context.Step.Remove(step);
            await _context.SaveChangesAsync();

            return step;
        }

        private bool StepExists(int id)
        {
            return _context.Step.Any(e => e.StepId == id);
        }
    }
}
