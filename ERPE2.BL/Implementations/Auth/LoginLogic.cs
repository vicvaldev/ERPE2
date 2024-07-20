using ERPE2.BL.Interfaces.Auth;
using ERPE2.Context.Repository.Interfaces;
using ERPE2.CrossLogic.Auth;
using ERPE2.Dto;
using ERPE2.Dto.Requests;
using ERPE2.Dto.Responses;
using Microsoft.Extensions.Configuration;

namespace ERPE2.BL.Implementations.Auth;

public class LoginLogic : ILoginLogic
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public LoginLogic(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public Result<string> Login(LoginRequest user)
    {
        // Validar que el usuario exista
        var existingUser = _userRepository.GetUser(user);
        if (existingUser != null)
        {
            // Validar constraseña del usuario
            var Pepper = _configuration["Settings:Pepper"];
            var validUSer = PasswordHasher.VerifyPassword(user.Password, existingUser.Password, Pepper);
            if (!validUSer)
            {
                return Result<string>.Failure("Usuario o contraseña incorrectos");
            }
        }
        // Generar Token
        var Issuer = _configuration["Settings:Issuer"];
        var Audience = _configuration["Settings:Audience"];
        var SecretKey = _configuration["Settings:SecretKey"];
        string token = GenerateJwt.GenerateToken(existingUser, SecretKey, Issuer, Audience);
        return Result<string>.Success(token); 
    }
}