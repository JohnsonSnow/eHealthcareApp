using eHealthcare.Dto;
using eHealthcare.Entities;

namespace eHealthcare.Services
{
    public interface IActiveIngredientService
    {
        Task<List<ActiveIngredient>> GetAllAsync();
        Task<ActiveIngredient> GetByIdAsync(int id);
        Task<int> UpdateAsync(int id, ActiveIngredient model);
        Task<ActiveIngredient> AddAsync(ActiveIngredientDTO modelDto);
        Task DeleteAsync(int productId);
        bool CheckExists(int id);
    }
}
