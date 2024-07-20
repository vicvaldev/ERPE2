using ERPE2.Dto;
using ERPE2.Dto.Requests;

namespace ERPE2.Context.Repository.Interfaces;

public interface IUserRepository
{
    UserDto Create(UserDto user);
    List<UserDto> Get();
    bool GetByEmail(UserDto user);
    UserDto GetUser(LoginRequest user);
}