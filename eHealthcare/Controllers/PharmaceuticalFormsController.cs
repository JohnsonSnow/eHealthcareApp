using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eHealthcare.Data;
using eHealthcare.Entities;
using eHealthcare.Services;

namespace eHealthcare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmaceuticalFormsController : ControllerBase
    {
        private readonly eHealthcareContext _context;
        private readonly ILogger<PharmaceuticalFormsController> _logger;
        private readonly IPharmaceuticalFormService _pharmaceuticalFormService;

        public PharmaceuticalFormsController(eHealthcareContext context, ILogger<PharmaceuticalFormsController> logger, IPharmaceuticalFormService pharmaceuticalFormService)
        {
            _context = context;
            _logger = logger;
            _pharmaceuticalFormService = pharmaceuticalFormService;
        }

        // GET: api/PharmaceuticalForms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PharmaceuticalForm>>> GetPharmaceuticalForms()
        {
          if (_context.PharmaceuticalForms == null)
          {
              return NotFound();
          }
            return await _context.PharmaceuticalForms.ToListAsync();
        }

        // GET: api/PharmaceuticalForms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PharmaceuticalForm>> GetPharmaceuticalForm(int id)
        {
          if (_context.PharmaceuticalForms == null)
          {
              return NotFound();
          }
            var pharmaceuticalForm = await _context.PharmaceuticalForms.FindAsync(id);

            if (pharmaceuticalForm == null)
            {
                return NotFound();
            }

            return pharmaceuticalForm;
        }

        // PUT: api/PharmaceuticalForms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPharmaceuticalForm(int id, PharmaceuticalForm pharmaceuticalForm)
        {
            if (id != pharmaceuticalForm.PharmaceuticalFormId)
            {
                return BadRequest();
            }

            _context.Entry(pharmaceuticalForm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PharmaceuticalFormExists(id))
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

        // POST: api/PharmaceuticalForms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PharmaceuticalForm>> PostPharmaceuticalForm(PharmaceuticalForm pharmaceuticalForm)
        {
          if (_context.PharmaceuticalForms == null)
          {
              return Problem("Entity set 'eHealthcareContext.PharmaceuticalForms'  is null.");
          }
            var result = await _pharmaceuticalFormService.AddAsync(pharmaceuticalForm);


            return CreatedAtAction("GetPharmaceuticalForm", new { id = result.PharmaceuticalFormId }, result);
        }

        // DELETE: api/PharmaceuticalForms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePharmaceuticalForm(int id)
        {
            if (_context.PharmaceuticalForms == null)
            {
                return NotFound();
            }
            var pharmaceuticalForm = await _context.PharmaceuticalForms.FindAsync(id);
            if (pharmaceuticalForm == null)
            {
                return NotFound();
            }

            _context.PharmaceuticalForms.Remove(pharmaceuticalForm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PharmaceuticalFormExists(int id)
        {
            return (_context.PharmaceuticalForms?.Any(e => e.PharmaceuticalFormId == id)).GetValueOrDefault();
        }
    }
}
