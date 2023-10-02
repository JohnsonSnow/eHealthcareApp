using eHealthcare.Controllers;
using eHealthcare.Data;
using eHealthcare.Dto;
using eHealthcare.Entities;
using eHealthcare.Repositories;
using eHealthcare.Repositories.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace eHealthcare.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productrepository;
        private readonly ILoggingService _logger;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;


        public ProductService(IProductRepository productrepository, IHubContext<BroadcastHub, IHubClient> hubContext,  ILoggingService logger)
        {
            _productrepository = productrepository;
            _hubContext = hubContext;
            _logger = logger;
        }

        public async Task<Product> AddproductAsync(ProductDTO productDto)
        {
            try
            {
               
              var product = await _productrepository.AddproductAsync(productDto);
              _logger.LogInformation($"product as been created successfully with following details: {product}");
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
            await _productrepository.DeleteProductAsync(productId);

        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
           var product = await _productrepository.GetProductByIdAsync(productId);
           return product;
        }

        public async Task<Product> GetProductByNameAsync(string productName)
        {
            var product = await _productrepository.GetProductByNameAsync(productName);
            if (product == null)
            {
                return null;
            }
            return product;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var products = await _productrepository.GetProductsAsync();
            return products;
        }

        public async Task<int> UpdateProductAsync(int id, Product product)
        {
            var result = await _productrepository.UpdateProductAsync(id, product);
            return result;
        }

        public bool ProductExists(int id)
        {
            return _productrepository.ProductExists(id);
        }
    }
}
