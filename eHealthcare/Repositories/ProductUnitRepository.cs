using eHealthcare.Dto;
using eHealthcare.Entities;

namespace eHealthcare.Repositories
{
    public class ProductUnitRepository : IProductUnitRepository
    {
        public Task<ProductUnit> AddAsync(ProductUnitDTO modelDto)
        {
            throw new NotImplementedException();
        }

        public bool CheckExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductUnit>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductUnit> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(int id, ProductUnit model)
        {
            throw new NotImplementedException();
        }
    }
}
