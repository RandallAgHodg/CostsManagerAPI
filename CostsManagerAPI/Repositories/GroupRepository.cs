using CostsManagerAPI.Contracts.Data;
using CostsManagerAPI.Database;
using CostsManagerAPI.Domain;
using CostsManagerAPI.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CostsManagerAPI.Repositories;

public class GroupRepository : IGroupRepository
{
    private readonly ApplicationDbContext _context;

    public GroupRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(GroupDto groupDto)
    {
        var group = groupDto.ToGroup();
        _context.Add(group);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<GroupDto?> GetAsync(Guid id)
    {
        var group = await _context.Groups
            .Include(g => g.Costs)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        return group?.ToGroupDto();
    }

    public async Task<IEnumerable<GroupDto>> GetAllAsync()
    {
        var groups = await _context.Groups
            .Include(g => g.Costs)
            .AsNoTracking()
            .ToListAsync();
        return groups.Select(x => x.ToGroupDto());
    }

    public async Task<bool> UpdateAsync(GroupDto groupDto)
    {
        var group = groupDto.ToGroup();
        _context.Groups.Update(group);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        _context.Remove(new Group()
        {
            Id = id
        });

        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}