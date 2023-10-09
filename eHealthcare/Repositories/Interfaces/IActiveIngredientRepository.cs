using eHealthcare.Dto;
using eHealthcare.Entities;

namespace eHealthcare.Repositories.Interfaces
{
    public interface IActiveIngredientRepository
    {
        Task<List<ActiveIngredient>> GetAllAsync();
        Task<ActiveIngredient> GetByIdAsync(int id);
        Task<int> UpdateAsync(int id, ActiveIngredient model);
        Task<ActiveIngredient> AddAsync(ActiveIngredientDTO modelDto);
        Task DeleteAsync(int productId);
        bool CheckExists(int id);
    }
}
