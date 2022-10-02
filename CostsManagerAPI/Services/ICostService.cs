using CostsManagerAPI.Domain;

namespace CostsCManagerAPI.Services;

public interface ICostService
{
    Task<bool> CreateAsync(Cost cost);
    Task<Cost?> GetAsync(Guid id);
    Task<IEnumerable<Cost>> GetAllAsync();
    Task<bool> UpdateAsync(Cost cost);
    Task<bool> DeleteAsync(Guid id);
}