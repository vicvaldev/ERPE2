using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ERPE2.Dto;
using Microsoft.IdentityModel.Tokens;

namespace ERPE2.CrossLogic.Auth;

public class GenerateJwt
{
    public static string GenerateToken(UserDto user, string secretKey, string Issuer, string Audience)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.RolId.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: Issuer,
            audience: Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}