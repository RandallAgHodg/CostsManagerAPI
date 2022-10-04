using CostsManagerAPI.Contracts.Data;

namespace CostsManagerAPI.Repositories;

public interface ICostRepository
{
    Task<CostDto?> GetAsync(Guid id);
    Task<IEnumerable<CostDto>> GetAllAsync(Guid groupId);
    Task<bool> CreateAsync(CostDto costDto);
    Task<bool> UpdateAsync(CostDto costDto);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> FindByNameAsync(string name);
}