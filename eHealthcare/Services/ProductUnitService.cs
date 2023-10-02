using eHealthcare.Dto;
using eHealthcare.Entities;
using eHealthcare.Repositories.Interfaces;
using eHealthcare.Repositories;

namespace eHealthcare.Services
{
    public class ProductUnitService : IProductUnitService
    {
        private readonly IProductUnitRepository _productUnitRepository;
        private readonly ILoggingService _logger;

        public ProductUnitService(IProductUnitRepository productUnitRepository, ILoggingService logger)
        {
            _productUnitRepository = productUnitRepository;
            _logger = logger;
        }

        public async Task<ProductUnit> AddAsync(ProductUnitDTO modelDto)
        {
            try
            {

                var result = await _productUnitRepository.AddAsync(modelDto);
                _logger.LogInformation($"item has been created successfully with following details: {result}");
                return result;

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString(), "An error occured when adding item.");
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
