using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eHealthcare.Data;
using eHealthcare.Entities;
using Microsoft.AspNetCore.SignalR;
using eHealthcare.Dto;

namespace eHealthcare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly eHealthcareContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(eHealthcareContext context, IHubContext<BroadcastHub, IHubClient> hubContext = null, ILogger<ProductsController> logger = null)
        {
            _context = context;
            _hubContext = hubContext;
            _logger = logger;
        }


        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
          if (_context.Product == null)
          {
              return NotFound();
          }
            return await _context.Product.Include("TherapeuticClass").ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
          if (_context.Product == null)
          {
              return NotFound();
          }
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            Notification notification = new Notification()
            {
                Title = "Product Updated",
                Description = $"This product: {product.Name} has been updated by someone.",
                TranType = "Update"
            };

            try
            {
                await _context.SaveChangesAsync();
                await _hubContext.Clients.All.BroadcastMessage(notification);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductDTO productDto)
        {
          if (_context.Product == null)
          {
              return Problem("Entity set 'eHealthcareContext.Product'  is null.");
          }

            var product = new Product
            {
                //Id = productDto.Id,
                Name = productDto.Name,
                Classifications = productDto.Classifications,
                CompetentAuthorityStatus = productDto.CompetentAuthorityStatus,
                InternalStatus = productDto.InternalStatus,
                ActiveIngredientID = productDto.ActiveIngredientID,
                ProductUnitID = productDto.ProductUnitID,
                PharmaceuticalFormID = productDto.PharmaceuticalFormID,
                TherapeuticClassID = productDto.TherapeuticClassID,
                ATCCodeID = productDto.ATCCodeID,
                ActiveIngredient = await _context.ActiveIngredients.FindAsync(productDto.ActiveIngredientID),
                PharmaceuticalForm = await _context.PharmaceuticalForms.FindAsync(productDto.PharmaceuticalFormID),
                TherapeuticClass = await _context.TherapeuticClass.FindAsync(productDto.TherapeuticClassID),
                ProductUnit = await _context.ProductUnits.FindAsync(productDto.ProductUnitID)

          };

            _context.Product.Add(product);
            Notification notification = new Notification()
            {
                Title = "Product Added",
                Description = $"A new product: {product.Name} has been added by someone.",
                TranType = "Create"
            };
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.BroadcastMessage(notification);

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Product == null)
            {
                return NotFound();
            }
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            Notification notification = new Notification()
            {
                Title = "Product Deleted",
                Description = $"This product: {product.Name} has been deleted by someone.",
                TranType = "Delete"
            };

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.BroadcastMessage(notification);

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
