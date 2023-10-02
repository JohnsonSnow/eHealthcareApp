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
using eHealthcare.Services;

namespace eHealthcare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly eHealthcareContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;
        public ProductsController(eHealthcareContext context, IHubContext<BroadcastHub, IHubClient> hubContext = null, ILogger<ProductsController> logger = null, IProductService productService = null)
        {
            _context = context;
            _hubContext = hubContext;
            _logger = logger;
            _productService = productService;
        }


        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            if (_context.Product == null)
            {
                return NotFound();
            }

           var product = await _productService.GetProductsAsync();
         
            return product;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
          if (_context.Product == null)
          {
              return NotFound();
          }
           var product = await _productService.GetProductByIdAsync(id);
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
            _logger.LogInformation($"starting update product process with this product Details: {product} and product Id: {id}");

            if (id != product.Id)
            {
                return BadRequest();
            }
            var result = await _productService.UpdateProductAsync(id, product);
            if (result == 0)
            {
                return NotFound();
            }


            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductDTO productDto)
        {
            _logger.LogInformation($"starting add product process with this product Details: {productDto}");
            if (_context.Product == null)
            {
                return Problem("Entity set 'eHealthcareContext.Product'  is null.");
            }

           var result = await _productService.AddproductAsync(productDto);

          

            return CreatedAtAction("GetProduct", new { id = result.Id }, result);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Product == null)
            {
                return NotFound();
            }
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }

       
    }
}
