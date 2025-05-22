using MPCalcHub.Domain.Entities;

namespace MPCalcHub.Domain.Interfaces;

public interface IContactService : IBaseService<Contact>
{
    Task<Contact> GetById(Guid id, bool include, bool tracking);
    Task Remove(Guid id);
}