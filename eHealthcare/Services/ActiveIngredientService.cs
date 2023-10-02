using eHealthcare.Dto;
using eHealthcare.Entities;

namespace eHealthcare.Services
{
    public class ActiveIngredientService : IActiveIngredientService
    {
        public Task<ActiveIngredient> AddAsync(ActiveIngredientDTO modelDto)
        {
            throw new NotImplementedException();
        }

        public bool CheckExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ActiveIngredient>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ActiveIngredient> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(int id, ActiveIngredient model)
        {
            throw new NotImplementedException();
        }
    }
}
