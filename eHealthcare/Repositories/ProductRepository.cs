using eHealthcare.Data;
using eHealthcare.Dto;
using eHealthcare.Entities;
using eHealthcare.Repositories.Interfaces;
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

      
        /// <summary>
        /// Add product
        /// </summary>
        /// <param name="productDto"></param>
        /// <returns></returns>
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
                    ActiveIngredientId = productDto.ActiveIngredientID,
                    ProductUnitId = productDto.ProductUnitID,
                    PharmaceuticalFormId = productDto.PharmaceuticalFormID,
                    TherapeuticClassId = productDto.TherapeuticClassID,
                    ATCCodeId = productDto.ATCCodeID,
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
                    Id = Guid.NewGuid(),
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

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task DeleteProductAsync(int productId)
        {
            var product = await _context.Product.FindAsync(productId);
            if (product == null)
            {
                return;
            }

            Notification notification = new Notification()
            {
                Id = Guid.NewGuid(),
                Title = "Product Deleted",
                Description = $"This product: {product.Name} has been deleted by someone.",
                TranType = "Delete"
            };

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.BroadcastMessage(notification);

        }

        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
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
                product!.ActiveIngredient = await _context.ActiveIngredients.FindAsync(product.ActiveIngredientId);
                product!.PharmaceuticalForm = await _context.PharmaceuticalForms.FindAsync(product.PharmaceuticalFormId);
                product!.TherapeuticClass = await _context.TherapeuticClass.FindAsync(product.TherapeuticClassId);
                product!.ProductUnit = await _context.ProductUnits.FindAsync(product.ProductUnitId);
                product!.ATCCode = await _context.ATCCode.FindAsync(product.ATCCodeId);

                return product;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString(), $"An error occured when getting productId: {productId}");
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
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
                Id= Guid.NewGuid(),
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
                    return 0; // doing this cause i'm not creating a custom exceptions handler.
                }
                else
                {
                    _logger.LogInformation(ex.Message.ToString(), $"An error occured when updating productId: {id}");

                    throw;
                }
            }
            return 1;// doing this cause i'm not creating a custom exceptions handler.
        }

        public bool ProductExists(int id)
        {
            return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }

 
    }
}
