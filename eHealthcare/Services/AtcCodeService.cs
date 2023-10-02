using eHealthcare.Dto;
using eHealthcare.Entities;

namespace eHealthcare.Services
{
    public class AtcCodeService : IAtcCodeService
    {
        public Task<ATCCode> AddAsync(ATCCodeDTO modelDto)
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
