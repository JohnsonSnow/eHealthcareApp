using eHealthcare.Dto;
using eHealthcare.Entities;

namespace eHealthcare.Services
{
    public class TherapeuticalClassService : ITherapeuticalClassService
    {
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
