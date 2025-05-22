using MPCalcHub.Domain.Entities;

namespace MPCalcHub.Domain.Interfaces.Security;

public interface ITokenService
{
    string GenerateToken(User user, bool force = false);
}