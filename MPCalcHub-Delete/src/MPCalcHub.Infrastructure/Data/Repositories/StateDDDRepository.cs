using MPCalcHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MPCalcHub.Domain.Interfaces.Infrastructure;

namespace MPCalcHub.Infrastructure.Data.Repositories;

public class StateDDDRepository : IStateDDDRepository
{
    private readonly ApplicationDBContext _context;

    public StateDDDRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<StateDDD> GetByDDDAsync(int ddd)
    {
        return await _context.Set<StateDDD>()
            .Where(s => s.DDD == ddd)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<StateDDD>> GetByRegionAsync(string region)
    {
        return await _context.Set<StateDDD>()
            .Where(s => s.Region.Contains(region))
            .ToListAsync();
    }

    public async Task<IEnumerable<StateDDD>> GetByStateAsync(string state)
    {
        return await _context.Set<StateDDD>()
            .Where(s => s.State.Contains(state))
            .ToListAsync();
    }
}