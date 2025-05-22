using MPCalcHub.Domain.Entities;

namespace MPCalcHub.Domain.Interfaces.Infrastructure;

public interface IContactRepository : IRepository<Contact>
{
    Task<Contact> GetById(Guid id, bool include = false, bool tracking = false);
    Task<Contact> GetByEmail(string email, bool include = false, bool tracking = false);
    Task<IEnumerable<Contact>> FindBy(int ddd);
}