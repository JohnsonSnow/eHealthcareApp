﻿using eHealthcare.Dto;
using eHealthcare.Entities;

namespace eHealthcare.Repositories
{
    public interface IPharmaceuticalFormRepository
    {
        Task<List<PharmaceuticalForm>> GetAllAsync();
        Task<PharmaceuticalForm> GetByIdAsync(int id);
        Task<int> UpdateAsync(int id, PharmaceuticalForm model);
        Task<PharmaceuticalForm> AddAsync(PharmaceuticalForm modelDto);
        Task DeleteAsync(int id);
        bool CheckExists(int id);
    }
}
