using MPCalcHub.Application.DataTransferObjects;

namespace MPCalcHub.Application.Interfaces
{
    public interface ITokenApplicationService
    {
        Task<string> GetToken(UserLogin userLogin);
        Task<string> GetTokenByAutorization(string email);
    }
}