using eHealthcare.Dto;
using eHealthcare.Entities;

namespace eHealthcare.Services
{
    public interface ITherapeuticalClassService
    {
        Task<List<TherapeuticClass>> GetAllAsync();
        Task<TherapeuticClass> GetByIdAsync(int id);
        Task<int> UpdateAsync(int id, TherapeuticClass model);
        Task<TherapeuticClass> AddAsync(TherapeuticClassDTO modelDto);
        Task DeleteAsync(int id);
        bool CheckExists(int id);
    }
}
