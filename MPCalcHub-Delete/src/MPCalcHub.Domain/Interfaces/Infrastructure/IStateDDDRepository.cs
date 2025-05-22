using MPCalcHub.Domain.Entities;

namespace MPCalcHub.Domain.Interfaces.Infrastructure;

public interface IStateDDDRepository
{
    Task<StateDDD> GetByDDDAsync(int ddd);
    Task<IEnumerable<StateDDD>> GetByStateAsync(string state);
    Task<IEnumerable<StateDDD>> GetByRegionAsync(string state);
}