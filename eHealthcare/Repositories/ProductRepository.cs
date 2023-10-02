using eHealthcare.Data;
using eHealthcare.Dto;
using eHealthcare.Entities;
using eHealthcare.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace eHealthcare.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly eHealthcareContext _context;
        private readonly ILogger<ProductRepository> _logger;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public ProductRepository(eHealthcareContext context, ILogger<ProductRepository> logger, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _context = context;
            _logger = logger;
            _hubContext = hubContext;
        }

      

        public async Task<Product> AddproductAsync(ProductDTO productDto)
        {
            try
            {
                var product = new Product
                {
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
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Product has been created: {product}");

                Notification notification = new Notification()
                {
                    Title = "Product Added",
                    Description = $"A new product: {productDto.Name} has been added by someone.",
                    TranType = "Create"
                };
                await _hubContext.Clients.All.BroadcastMessage(notification);
                _logger.LogInformation($"sending out notification log: {notification}");

                return product;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString(), "An error occured when adding product.");
                throw;
            }
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _context.Product.FindAsync(productId);
            if (product == null)
            {
                return;
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

        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            _logger.LogInformation($"Getting Product {productId}");
            try
            {
                var product = await _context.Product.FindAsync(productId);
                if (product == null)
                {
                    return null;
                }
                product!.ActiveIngredient = await _context.ActiveIngredients.FindAsync(product.ActiveIngredientID);
                product!.PharmaceuticalForm = await _context.PharmaceuticalForms.FindAsync(product.PharmaceuticalFormID);
                product!.TherapeuticClass = await _context.TherapeuticClass.FindAsync(product.TherapeuticClassID);
                product!.ProductUnit = await _context.ProductUnits.FindAsync(product.ProductUnitID);
                product!.ATCCode = await _context.ATCCode.FindAsync(product.ATCCodeID);

                return product;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString(), $"An error occured when getting productId: {productId}");
                throw;
            }
        }

        public Task<Product> GetProductByNameAsync(string productName)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            _logger.LogInformation($"Getting Products");

            try
            {
                var product = await _context.Product
                                       .Include(p => p.TherapeuticClass)
                                       .Include(p => p.ATCCode)
                                       .Include(p => p.PharmaceuticalForm)
                                       .Include(p => p.ActiveIngredient)
                                       .Include(p => p.ProductUnit)
                                       .ToListAsync();
                return product;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString(), $"An error occured when getting products");

                throw;
            }
        }

        public async Task<int> UpdateProductAsync(int id, Product product)
        {
            _context.Entry(product).State = EntityState.Modified;

            Notification notification = new Notification()
            {
                Title = "Product Updated",
                Description = $"This product: {product.Name} has been updated by someone.",
                TranType = "Update"
            };
            await _hubContext.Clients.All.BroadcastMessage(notification);


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ProductExists(id))
                {
                    return 0;
                }
                else
                {
                    _logger.LogInformation(ex.Message.ToString(), $"An error occured when updating productId: {id}");

                    throw;
                }
            }
            return 1;
        }

        public bool ProductExists(int id)
        {
            return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }

 
    }
}
