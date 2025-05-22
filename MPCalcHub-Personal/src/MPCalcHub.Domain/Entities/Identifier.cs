using MPCalcHub.Domain.Entities.Interfaces;

namespace MPCalcHub.Domain.Entities;

public abstract class Identifier : IIdentifier
{
    public Guid Id { get; set; }
}