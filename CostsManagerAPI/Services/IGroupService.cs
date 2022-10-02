using CostsManagerAPI.Domain;

namespace CostsManagerAPI.Services;

public interface IGroupService
{
    Task<bool> CreateAsync(Group group);
    Task<Group?> GetAsync(Guid id);
    Task<IEnumerable<Group>> GetAllAsync();
    Task<bool> UpdateAsync(Group group);
    Task<bool> DeleteAsync(Guid id);
}