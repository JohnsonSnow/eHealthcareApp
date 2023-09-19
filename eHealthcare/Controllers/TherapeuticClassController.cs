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
    public class TherapeuticClassController : ControllerBase
    {
        private readonly eHealthcareContext _context;

        public TherapeuticClassController(eHealthcareContext context)
        {
            _context = context;
        }

        // GET: api/TherapeuticClass
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TherapeuticClass>>> GetTherapeuticClass()
        {
          if (_context.TherapeuticClass == null)
          {
              return NotFound();
          }
            return await _context.TherapeuticClass.ToListAsync();
        }

        // GET: api/TherapeuticClass/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TherapeuticClass>> GetTherapeuticClass(Guid id)
        {
          if (_context.TherapeuticClass == null)
          {
              return NotFound();
          }
            var therapeuticClass = await _context.TherapeuticClass.FindAsync(id);

            if (therapeuticClass == null)
            {
                return NotFound();
            }

            return therapeuticClass;
        }

        // PUT: api/TherapeuticClass/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTherapeuticClass(int id, TherapeuticClass therapeuticClass)
        {
            if (id != therapeuticClass.TherapeuticClassId)
            {
                return BadRequest();
            }

            _context.Entry(therapeuticClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TherapeuticClassExists(id))
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

        // POST: api/TherapeuticClass
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TherapeuticClass>> PostTherapeuticClass(TherapeuticClass therapeuticClass)
        {
          if (_context.TherapeuticClass == null)
          {
              return Problem("Entity set 'eHealthcareContext.TherapeuticClass'  is null.");
          }
            _context.TherapeuticClass.Add(therapeuticClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTherapeuticClass", new { id = therapeuticClass.TherapeuticClassId }, therapeuticClass);
        }

        // DELETE: api/TherapeuticClass/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTherapeuticClass(int id)
        {
            if (_context.TherapeuticClass == null)
            {
                return NotFound();
            }
            var therapeuticClass = await _context.TherapeuticClass.FindAsync(id);
            if (therapeuticClass == null)
            {
                return NotFound();
            }

            _context.TherapeuticClass.Remove(therapeuticClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TherapeuticClassExists(int id)
        {
            return (_context.TherapeuticClass?.Any(e => e.TherapeuticClassId == id)).GetValueOrDefault();
        }
    }
}
