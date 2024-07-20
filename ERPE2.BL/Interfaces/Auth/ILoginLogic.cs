using ERPE2.Dto;
using ERPE2.Dto.Requests;
using ERPE2.Dto.Responses;

namespace ERPE2.BL.Interfaces.Auth;

public interface ILoginLogic
{
    Result<string> Login(LoginRequest user);
}