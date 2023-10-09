using eHealthcare.Dto;
using eHealthcare.Entities;
using eHealthcare.Repositories.Interfaces;
using eHealthcare.Services;
using Microsoft.CodeAnalysis;

namespace eHealthcare.Services
{
    public class ActiveIngredientService : IActiveIngredientService
    {
        private readonly IActiveIngredientRepository _activeIngredientRepository;
        private readonly ILoggingService _logger;

        public ActiveIngredientService(IActiveIngredientRepository activeIngredientRepository, ILoggingService logger)
        {
            _activeIngredientRepository = activeIngredientRepository;
            _logger = logger;
        }

        public async Task<ActiveIngredient> AddAsync(ActiveIngredientDTO modelDto)
        {
            try
            {

                var result = await _activeIngredientRepository.AddAsync(modelDto);
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

        public Task DeleteAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ActiveIngredient>> GetAllAsync()
        {
            var result = await _activeIngredientRepository.GetAllAsync();
            return result;
        }

        public async Task<ActiveIngredient> GetByIdAsync(int id)
        {
            var result = await _activeIngredientRepository.GetByIdAsync(id);
            return result;
        }

        public Task<int> UpdateAsync(int id, ActiveIngredient model)
        {
            throw new NotImplementedException();
        }
    }
}
