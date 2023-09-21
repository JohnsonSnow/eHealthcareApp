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
    public class ProductUnitsController : ControllerBase
    {
        private readonly eHealthcareContext _context;

        public ProductUnitsController(eHealthcareContext context)
        {
            _context = context;
        }

        // GET: api/ProductUnits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductUnit>>> GetProductUnits()
        {
          if (_context.ProductUnits == null)
          {
              return NotFound();
          }
            return await _context.ProductUnits.ToListAsync();
        }

        // GET: api/ProductUnits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductUnit>> GetProductUnit(int id)
        {
          if (_context.ProductUnits == null)
          {
              return NotFound();
          }
            var productUnit = await _context.ProductUnits.FindAsync(id);

            if (productUnit == null)
            {
                return NotFound();
            }

            return productUnit;
        }

        // PUT: api/ProductUnits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductUnit(int id, ProductUnit productUnit)
        {
            if (id != productUnit.ProductUnitId)
            {
                return BadRequest();
            }

            _context.Entry(productUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductUnitExists(id))
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

        // POST: api/ProductUnits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductUnit>> PostProductUnit(ProductUnit productUnit)
        {
          if (_context.ProductUnits == null)
          {
              return Problem("Entity set 'eHealthcareContext.ProductUnits'  is null.");
          }
            _context.ProductUnits.Add(productUnit);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductUnitExists(productUnit.ProductUnitId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductUnit", new { id = productUnit.ProductUnitId }, productUnit);
        }

        // DELETE: api/ProductUnits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductUnit(int id)
        {
            if (_context.ProductUnits == null)
            {
                return NotFound();
            }
            var productUnit = await _context.ProductUnits.FindAsync(id);
            if (productUnit == null)
            {
                return NotFound();
            }

            _context.ProductUnits.Remove(productUnit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductUnitExists(int id)
        {
            return (_context.ProductUnits?.Any(e => e.ProductUnitId == id)).GetValueOrDefault();
        }
    }
}
