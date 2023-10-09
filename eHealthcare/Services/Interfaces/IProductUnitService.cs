using eHealthcare.Dto;
using eHealthcare.Entities;

namespace eHealthcare.Services
{
    public interface IProductUnitService
    {
        Task<List<ProductUnit>> GetAllAsync();
        Task<ProductUnit> GetByIdAsync(int id);
        Task<int> UpdateAsync(int id, ProductUnit model);
        Task<ProductUnit> AddAsync(ProductUnitDTO modelDto);
        Task DeleteAsync(int id);
        bool CheckExists(int id);
    }
}
