using MPCalcHub.Domain.Entities;

namespace MPCalcHub.Domain.Interfaces;

public interface IUserService : IBaseService<User>
{
    Task<User> GetById(Guid id);
    Task<User> GetByEmail(string email);
}