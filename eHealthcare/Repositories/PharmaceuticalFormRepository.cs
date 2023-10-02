using eHealthcare.Entities;

namespace eHealthcare.Repositories
{
    public class PharmaceuticalFormRepository : IPharmaceuticalFormRepository
    {
        public Task<PharmaceuticalForm> AddAsync(PharmaceuticalForm modelDto)
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
