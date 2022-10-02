using CostsManagerAPI.Contracts.Data;
using CostsManagerAPI.Database;
using CostsManagerAPI.Domain;
using CostsManagerAPI.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CostsManagerAPI.Repositories;

public class CostRepository : ICostRepository
{
    private readonly ApplicationDbContext _context;

    public CostRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CostDto?> GetAsync(Guid id)
    {
        var cost = await _context.Costs.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        return cost?.ToCostDto();
    }

    public async Task<IEnumerable<CostDto>> GetAllAsync()
    {
        var costs = await _context.Costs.AsNoTracking().ToListAsync();
        return costs.Select(cost => cost.ToCostDto());
    }

    public async Task<bool> CreateAsync(CostDto costDto)
    {
        var cost = costDto.ToCost();
        await _context.Costs.AddAsync(cost);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> UpdateAsync(CostDto costDto)
    {
        var cost = costDto.ToCost();
        _context.Costs.Update(cost);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        _context.Remove(new Cost()
        {
            Id = id
        });

        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> FindByNameAsync(string name)
    {
        return await _context.Costs.AnyAsync(
            x => x.Name.Contains(name));
    }
}