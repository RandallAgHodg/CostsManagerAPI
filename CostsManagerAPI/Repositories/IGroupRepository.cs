using CostsManagerAPI.Contracts.Data;

namespace CostsManagerAPI.Repositories;

public interface IGroupRepository
{
    Task<bool> CreateAsync(GroupDto groupDto);
    Task<GroupDto?> GetAsync(Guid id);
    Task<IEnumerable<GroupDto>> GetAllAsync();
    Task<bool> UpdateAsync(GroupDto groupDto);
    Task<bool> DeleteAsync(Guid id);
}