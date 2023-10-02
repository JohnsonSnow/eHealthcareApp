using eHealthcare.Data;
using eHealthcare.Dto;
using eHealthcare.Entities;
using eHealthcare.Services;

namespace eHealthcare.Repositories
{
    public class TherapeuticalClassRepository : ITherapeuticalClassRepository
    {
        private readonly eHealthcareContext _context;
        private readonly ILogger<TherapeuticalClassRepository> _logger;

        public TherapeuticalClassRepository(eHealthcareContext context, ILogger<TherapeuticalClassRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<TherapeuticClass> AddAsync(TherapeuticClassDTO modelDto)
        {
            try
            {
                var model = new TherapeuticClass
                {
                    Name = modelDto.Name,
                };
                _context.TherapeuticClass.Add(model);
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
