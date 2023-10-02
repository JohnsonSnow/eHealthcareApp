using eHealthcare.Dto;
using eHealthcare.Entities;

namespace eHealthcare.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task<Product> GetProductByNameAsync(string productName);
        Task<int> UpdateProductAsync(int id, Product product);
        Task<Product> AddproductAsync(ProductDTO productDto);
        Task DeleteProductAsync(int productId);
        bool ProductExists(int id);
    }
}
