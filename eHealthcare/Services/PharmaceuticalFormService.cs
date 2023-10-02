using eHealthcare.Entities;
using eHealthcare.Repositories.Interfaces;
using eHealthcare.Repositories;

namespace eHealthcare.Services
{
    public class PharmaceuticalFormService : IPharmaceuticalFormService
    {
        private readonly IPharmaceuticalFormRepository _pharmaceuticalFormRepository;
        private readonly ILoggingService _logger;

        public PharmaceuticalFormService(IPharmaceuticalFormRepository pharmaceuticalFormRepository, ILoggingService logger)
        {
            _pharmaceuticalFormRepository = pharmaceuticalFormRepository;
            _logger = logger;
        }

        public async Task<PharmaceuticalForm> AddAsync(PharmaceuticalForm modelDto)
        {
            try
            {

                var result = await _pharmaceuticalFormRepository.AddAsync(modelDto);
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

        public Task<List<PharmaceuticalForm>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PharmaceuticalForm> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(int id, PharmaceuticalForm model)
        {
            throw new NotImplementedException();
        }
    }
}
