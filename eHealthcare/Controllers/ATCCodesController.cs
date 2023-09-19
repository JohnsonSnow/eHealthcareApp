using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eHealthcare.Data;
using eHealthcare.Entities;

namespace eHealthcare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ATCCodesController : ControllerBase
    {
        private readonly eHealthcareContext _context;

        public ATCCodesController(eHealthcareContext context)
        {
            _context = context;
        }

        // GET: api/ATCCodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ATCCode>>> GetATCCode()
        {
          if (_context.ATCCode == null)
          {
              return NotFound();
          }
            return await _context.ATCCode.ToListAsync();
        }

        // GET: api/ATCCodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ATCCode>> GetATCCode(Guid id)
        {
          if (_context.ATCCode == null)
          {
              return NotFound();
          }
            var aTCCode = await _context.ATCCode.FindAsync(id);

            if (aTCCode == null)
            {
                return NotFound();
            }

            return aTCCode;
        }

        // PUT: api/ATCCodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutATCCode(int id, ATCCode aTCCode)
        {
            if (id != aTCCode.ATCCodeId)
            {
                return BadRequest();
            }

            _context.Entry(aTCCode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ATCCodeExists(id))
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

        // POST: api/ATCCodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ATCCode>> PostATCCode(ATCCode aTCCode)
        {
          if (_context.ATCCode == null)
          {
              return Problem("Entity set 'eHealthcareContext.ATCCode'  is null.");
          }
            _context.ATCCode.Add(aTCCode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetATCCode", new { id = aTCCode.ATCCodeId }, aTCCode);
        }

        // DELETE: api/ATCCodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteATCCode(int id)
        {
            if (_context.ATCCode == null)
            {
                return NotFound();
            }
            var aTCCode = await _context.ATCCode.FindAsync(id);
            if (aTCCode == null)
            {
                return NotFound();
            }

            _context.ATCCode.Remove(aTCCode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ATCCodeExists(int id)
        {
            return (_context.ATCCode?.Any(e => e.ATCCodeId == id)).GetValueOrDefault();
        }
    }
}
