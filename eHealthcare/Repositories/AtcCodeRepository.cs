using eHealthcare.Data;
using eHealthcare.Dto;
using eHealthcare.Entities;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace eHealthcare.Repositories
{
    public class AtcCodeRepository : IAtcCodeRepository
    {
        private readonly eHealthcareContext _context;
        private readonly ILogger<AtcCodeRepository> _logger;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public AtcCodeRepository(eHealthcareContext context, ILogger<AtcCodeRepository> logger, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _context = context;
            _logger = logger;
            _hubContext = hubContext;
        }

        public async Task<ATCCode> AddAsync(ATCCodeDTO modelDto)
        {
            try
            {
                var model = new ATCCode
                {
                    Code = modelDto.Code,
                };
                _context.ATCCode.Add(model);
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
