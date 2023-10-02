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

        public Task<TherapeuticClass> AddAsync(TherapeuticClassDTO modelDto)
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
