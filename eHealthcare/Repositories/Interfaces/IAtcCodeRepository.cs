using eHealthcare.Dto;
using eHealthcare.Entities;

namespace eHealthcare.Repositories.Interfaces
{
    public interface IAtcCodeRepository
    {
        Task<List<ATCCode>> GetAllAsync();
        Task<ATCCode> GetByIdAsync(int id);
        Task<int> UpdateAsync(int id, ATCCode model);
        Task<ATCCode> AddAsync(ATCCodeDTO modelDto);
        Task DeleteAsync(int id);
        bool CheckExists(int id);
    }
}
