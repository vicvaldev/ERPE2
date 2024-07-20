using ERPE2.Context.Models;
using ERPE2.Context.Repository.Interfaces;
using ERPE2.Dto;
using ERPE2.Dto.Requests;

namespace ERPE2.Context.Repository.Implementations;

public class UserRepository : IBaseRepository<UserDto, User>, IUserRepository
{
    private readonly IE2ContextImplementation _context;

    public UserRepository(IE2ContextImplementation context)
    {
        _context = context;
    }

    public List<UserDto> Get()
    {
        var userContext= _context.GetRepository<User>();
        var userList = userContext.Get(includeProperties: "RolNavigation");
        return userList.Select(x => ToDto(x)).ToList();
    }

    public bool GetByEmail(UserDto user)
    {
        var userContext = _context.GetRepository<User>();
        var result = userContext.Get(x => x.Email == user.Email).Any();
        return result;
    }
    
    public UserDto GetUser(LoginRequest user)
    {
        var userContext = _context.GetRepository<User>();
        var result = userContext.Get(x => x.Email == user.Email).FirstOrDefault();
        return ToDto(result);
    }

    public UserDto Create(UserDto user)
    {
        var userContext = _context.GetRepository<User>();
        userContext.Insert(ToEntity(user));
        _context.Save();
        return user;
    }
    
    public UserDto ToDto(User entity)
    {
        if (entity == null) return null;

        return new UserDto()
        {
            Id = entity.Id,
            Email = entity.Email,
            Password = entity.Password,
            RolId = entity.RolId,
            RolNavigation = new RolRepository().ToDto(entity.RolNavigation)
        };
    }

    public User ToEntity(UserDto dto)
    {
        if (dto == null) return null;

        return new User()
        {
            Id = dto.Id,
            Email = dto.Email,
            Password = dto.Password,
            RolId = dto.RolId,
            RolNavigation = new RolRepository().ToEntity(dto.RolNavigation)
        };    
    }
}