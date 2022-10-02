using CostsManagerAPI.Domain;
using CostsManagerAPI.Mapping;
using CostsManagerAPI.Repositories;

namespace CostsManagerAPI.Services;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;
    
    public GroupService(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }
    
    public async Task<bool> CreateAsync(Group group)
    {
        var groupDto = group.ToGroupDto();
        return await _groupRepository.CreateAsync(groupDto);
    }

    public async Task<Group?> GetAsync(Guid id)
    {
        var group = await _groupRepository.GetAsync(id);
        return group?.ToGroup();
    }

    public async Task<IEnumerable<Group>> GetAllAsync()
    {
        var groups = await _groupRepository.GetAllAsync();
        return groups.Select(x => x.ToGroup());
    }

    public async Task<bool> UpdateAsync(Group group)
    {
        var groupDto = group.ToGroupDto();
        return await _groupRepository.UpdateAsync(groupDto);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _groupRepository.DeleteAsync(id);
    }

}