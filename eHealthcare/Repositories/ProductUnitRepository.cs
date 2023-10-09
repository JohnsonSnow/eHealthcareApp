using eHealthcare.Data;
using eHealthcare.Dto;
using eHealthcare.Entities;
using eHealthcare.Repositories.Interfaces;

namespace eHealthcare.Repositories
{
    public class ProductUnitRepository : IProductUnitRepository
    {
        private readonly eHealthcareContext _context;
        private readonly ILogger<ProductUnitRepository> _logger;

        public ProductUnitRepository(eHealthcareContext context, ILogger<ProductUnitRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ProductUnit> AddAsync(ProductUnitDTO modelDto)
        {
            try
            {
                var model = new ProductUnit
                {
                    UnitValue = modelDto.UnitValue,
                };
                _context.ProductUnits.Add(model);
                await _context.SaveChangesAsync();

                return model;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString(), $"An error occured!");
                throw;
            }
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
