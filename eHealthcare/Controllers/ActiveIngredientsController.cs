using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eHealthcare.Data;
using eHealthcare.Entities;
using eHealthcare.Dto;
using eHealthcare.Services;
using Microsoft.AspNetCore.SignalR;

namespace eHealthcare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiveIngredientsController : ControllerBase
    {
        private readonly eHealthcareContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        private readonly ILogger<ActiveIngredientsController> _logger;
        private readonly IActiveIngredientService _activeIngredientService;
        public ActiveIngredientsController(eHealthcareContext context, IHubContext<BroadcastHub, IHubClient> hubContext, ILogger<ActiveIngredientsController> logger, IActiveIngredientService activeIngredientService)
        {
            _context = context;
            _hubContext = hubContext;
            _logger = logger;
            _activeIngredientService = activeIngredientService;
        }

        // GET: api/ActiveIngredients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActiveIngredient>>> GetActiveIngredients()
        {
          if (_context.ActiveIngredients == null)
          {
              return NotFound();
          }
            return await _context.ActiveIngredients.ToListAsync();
        }

        // GET: api/ActiveIngredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActiveIngredient>> GetActiveIngredient(int id)
        {
          if (_context.ActiveIngredients == null)
          {
              return NotFound();
          }
            var activeIngredient = await _context.ActiveIngredients.FindAsync(id);

            if (activeIngredient == null)
            {
                return NotFound();
            }

            return activeIngredient;
        }

        // PUT: api/ActiveIngredients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActiveIngredient(int id, ActiveIngredient activeIngredient)
        {
            if (id != activeIngredient.ActiveIngredientId)
            {
                return BadRequest();
            }

            _context.Entry(activeIngredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActiveIngredientExists(id))
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

        // POST: api/ActiveIngredients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActiveIngredient>> PostActiveIngredient(ActiveIngredientDTO activeIngredientDTo)
        {
            _logger.LogInformation($"starting add item process with this product Details: {activeIngredientDTo}");

            if (_context.ActiveIngredients == null)
            {
                return Problem("Entity set 'eHealthcareContext.ActiveIngredients'  is null.");
            }
            var result = await _activeIngredientService.AddAsync(activeIngredientDTo);
          

            return CreatedAtAction("GetActiveIngredient", new { id = result.ActiveIngredientId }, result);
        }

        // DELETE: api/ActiveIngredients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActiveIngredient(int id)
        {
            if (_context.ActiveIngredients == null)
            {
                return NotFound();
            }
            var activeIngredient = await _context.ActiveIngredients.FindAsync(id);
            if (activeIngredient == null)
            {
                return NotFound();
            }

            _context.ActiveIngredients.Remove(activeIngredient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActiveIngredientExists(int id)
        {
            return (_context.ActiveIngredients?.Any(e => e.ActiveIngredientId == id)).GetValueOrDefault();
        }
    }
}
