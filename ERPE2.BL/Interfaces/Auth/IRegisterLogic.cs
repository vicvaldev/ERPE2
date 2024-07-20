using ERPE2.Dto;
using ERPE2.Dto.Responses;

namespace ERPE2.BL.Interfaces.Auth;

public interface IRegisterLogic
{
    Result<UserDto> Create(UserDto user);
}