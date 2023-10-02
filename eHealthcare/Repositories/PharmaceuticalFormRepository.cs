using eHealthcare.Data;
using eHealthcare.Entities;
using Microsoft.AspNetCore.SignalR;

namespace eHealthcare.Repositories
{
    public class PharmaceuticalFormRepository : IPharmaceuticalFormRepository
    {
        private readonly eHealthcareContext _context;
        private readonly ILogger<PharmaceuticalFormRepository> _logger;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public PharmaceuticalFormRepository(eHealthcareContext context, ILogger<PharmaceuticalFormRepository> logger, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _context = context;
            _logger = logger;
            _hubContext = hubContext;
        }

        public async Task<PharmaceuticalForm> AddAsync(PharmaceuticalForm modelDto)
        {
            try
            {
                var model = new PharmaceuticalForm
                {
                    Name = modelDto.Name,
                };
                _context.PharmaceuticalForms.Add(model);
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
