using CostsManagerAPI.Contracts;
using CostsManagerAPI.Domain;

namespace CostsManagerAPI.Repositories;

public interface ICostRepository
{
    Task<CostDto?> GetAsync(Guid id);
    Task<IEnumerable<CostDto>> GetAllAsync();
    Task<bool> CreateAsync(CostDto costDto);
    Task<bool> UpdateAsync(CostDto costDto);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> FindByNameAsync(string name);
}