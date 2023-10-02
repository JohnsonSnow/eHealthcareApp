using eHealthcare.Data;
using eHealthcare.Dto;
using eHealthcare.Entities;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace eHealthcare.Repositories
{
    public class ActiveIngredientRepository : IActiveIngredientRepository
    {
        private readonly eHealthcareContext _context;
        private readonly ILogger<ActiveIngredientRepository> _logger;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public ActiveIngredientRepository(eHealthcareContext context, ILogger<ActiveIngredientRepository> logger, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _context = context;
            _logger = logger;
            _hubContext = hubContext;
        }

        public async Task<ActiveIngredient> AddAsync(ActiveIngredientDTO modelDto)
        {
            try
            {
                var activeIngredient = new ActiveIngredient
                {
                    Name = modelDto.Name,
                };
               _context.ActiveIngredients.Add(activeIngredient);
                await _context.SaveChangesAsync();

                return activeIngredient;
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

        public Task DeleteAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ActiveIngredient>> GetAllAsync()
        {
            _logger.LogInformation($"Getting Active Ingredients");

            try
            {
                var result = await _context.ActiveIngredients.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString(), $"An error occured when getting items");

                throw;
            }
        }

        public async Task<ActiveIngredient> GetByIdAsync(int id)
        {
            _logger.LogInformation($"Getting Active Ingredient {id}");
            try
            {
                var result = await _context.ActiveIngredients.FindAsync(id);
                if (result == null)
                {
                    return null;
                }
               

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString(), $"An error occured when getting Id: {id}");
                throw;
            }
        }

        public Task<int> UpdateAsync(int id, ActiveIngredient model)
        {
            throw new NotImplementedException();
        }
    }
}
