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
    public class UOMcodesController : ControllerBase
    {
        private readonly ARMISContext _context;

        private IUOMService _uomService;

        public IUOMService Service
        {
            get 
            {
                if(_uomService == null) { _uomService = new UOMService(_context); }
                return _uomService; 
            }
            set { _uomService = value; }
        }


        public UOMcodesController(ARMISContext context)
        {
            _context = context;
        }

        // GET: api/UOMcodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UOMCodeModel>>> GetUomcode()
        {
            try 
            {
                var result = await Service.GetAllUOMs();

                return Ok(JsonSerializer.Serialize(result));
            }
            catch(Exception ex) { return BadRequest(ex.Message); } //TODO: Implement error handling.
        }

        // GET: api/UOMcodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Uomcode>> GetUOMcode(string id)
        {
            var uOMcode = await _context.Uomcode.FindAsync(id);

            if (uOMcode == null)
            {
                return NotFound();
            }

            return uOMcode;
        }

        // PUT: api/UOMcodes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUOMcode(string id, Uomcode uOMcode)
        {
            if (id != uOMcode.Uomcd)
            {
                return BadRequest();
            }

            _context.Entry(uOMcode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UOMcodeExists(id))
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

        // POST: api/UOMcodes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Uomcode>> PostUOMcode(Uomcode uOMcode)
        {
            _context.Uomcode.Add(uOMcode);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UOMcodeExists(uOMcode.Uomcd))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUOMcode", new { id = uOMcode.Uomcd }, uOMcode);
        }

        // DELETE: api/UOMcodes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Uomcode>> DeleteUOMcode(string id)
        {
            var uOMcode = await _context.Uomcode.FindAsync(id);
            if (uOMcode == null)
            {
                return NotFound();
            }

            _context.Uomcode.Remove(uOMcode);
            await _context.SaveChangesAsync();

            return uOMcode;
        }

        private bool UOMcodeExists(string id)
        {
            return _context.Uomcode.Any(e => e.Uomcd == id);
        }
    }
}
