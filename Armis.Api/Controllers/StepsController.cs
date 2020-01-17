using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Armis.Data.DatabaseContext;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.Services.ProcessServices;
using Armis.BusinessModels.ProcessModels;
using System.Text.Json;
using Armis.DataLogic.Services.ProcessServices.Interfaces;

namespace Armis.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepsController : ControllerBase
    {
        private readonly ARMISContext _context;

        private IStepService _stepService;

        public IStepService StepService { get; set; }


        public StepsController(ARMISContext context, IStepService aStepService)
        {
            _context = context;
            StepService = aStepService;
        }

        // GET: api/Steps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Step>>> GetAllHydratedSteps()
        {
            try
            {
                var data = await StepService.GetAllHydrated();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        // GET: api/Steps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Step>> GetStepById(int id)
        {
            try
            {
                var data = await StepService.GetHydratedStepById(id);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message + "\r\n" + ex.StackTrace);
            }
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
        public async Task<ActionResult<int>> PostStep(StepModel aStep)
        {
            try
            {
                var data = await StepService.CreateStep(aStep);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{aStepModel}")]
        public async Task<ActionResult<int>> PostVariablesToStep(StepModel aStepModel) //TODO: Can you pass in a model like this??????
        {
            try
            {
                var data = await StepService.AddVariablesToStep(aStepModel);

                return Ok(data);
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
