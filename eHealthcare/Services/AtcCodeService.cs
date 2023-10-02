using eHealthcare.Dto;
using eHealthcare.Entities;
using eHealthcare.Repositories.Interfaces;
using eHealthcare.Repositories;

namespace eHealthcare.Services
{
    public class AtcCodeService : IAtcCodeService
    {
        private readonly IAtcCodeRepository _atcCodeRepository;
        private readonly ILoggingService _logger;

        public AtcCodeService(IAtcCodeRepository atcCodeRepository, ILoggingService logger)
        {
            _atcCodeRepository = atcCodeRepository;
            _logger = logger;
        }

        public async Task<ATCCode> AddAsync(ATCCodeDTO modelDto)
        {
            try
            {

                var result = await _atcCodeRepository.AddAsync(modelDto);
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

        public Task<List<ATCCode>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ATCCode> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(int id, ATCCode model)
        {
            throw new NotImplementedException();
        }
    }
}
