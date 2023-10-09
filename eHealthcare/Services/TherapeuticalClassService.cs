using eHealthcare.Dto;
using eHealthcare.Entities;
using eHealthcare.Repositories;
using eHealthcare.Repositories.Interfaces;
using eHealthcare.Services;

namespace eHealthcare.Services
{
    public class TherapeuticalClassService : ITherapeuticalClassService
    {
        private readonly ITherapeuticalClassRepository _therapeuticalClassRepository;
        private readonly ILoggingService _logger;

        public TherapeuticalClassService(ITherapeuticalClassRepository therapeuticalClassRepository, ILoggingService logger)
        {
            _therapeuticalClassRepository = therapeuticalClassRepository;
            _logger = logger;
        }

        public async Task<TherapeuticClass> AddAsync(TherapeuticClassDTO modelDto)
        {
            try
            {

                var result = await _therapeuticalClassRepository.AddAsync(modelDto);
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

        public Task<List<TherapeuticClass>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TherapeuticClass> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(int id, TherapeuticClass model)
        {
            throw new NotImplementedException();
        }
    }
}
