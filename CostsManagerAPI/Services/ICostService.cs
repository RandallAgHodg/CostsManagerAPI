using CostsManagerAPI.Domain;

namespace CostsManagerAPI.Services;

public interface ICostService
{
    Task<bool> CreateAsync(Cost cost);
    Task<Cost?> GetAsync(Guid id);
    Task<IEnumerable<Cost>> GetAllAsync(Guid groupId);
    Task<bool> UpdateAsync(Cost cost);
    Task<bool> DeleteAsync(Guid id);
}