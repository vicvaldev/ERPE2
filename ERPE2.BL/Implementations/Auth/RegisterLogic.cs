using ERPE2.BL.Interfaces.Auth;
using ERPE2.Context.Models;
using ERPE2.Context.Repository.Interfaces;
using ERPE2.CrossLogic.Auth;
using ERPE2.Dto;
using ERPE2.Dto.Responses;
using Microsoft.Extensions.Configuration;

namespace ERPE2.BL.Implementations.Auth;

public class RegisterLogic : IRegisterLogic
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public RegisterLogic(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public Result<UserDto> Create(UserDto user)
    {
        // Validar si el usaurio existe
        var existingUser = _userRepository.GetByEmail(user);
        if (existingUser) return Result<UserDto>.Failure("El usuario ya existe.");
        
        // Generar salt
        var Pepper = _configuration["Settings:Pepper"];
        var passwordHashed = PasswordHasher.HashPassword(user.Password, Pepper);
        
        // Sí el usuario no existe, se crea.
        user.Password = passwordHashed;
        var newUser = _userRepository.Create(user);
        return Result<UserDto>.Success(newUser);
    }
}