using MPCalcHub.Application.DataTransferObjects;

namespace MPCalcHub.Application.Interfaces;

public interface IUserApplicationService
{   
    Task<User> Add(BasicUser model);
}