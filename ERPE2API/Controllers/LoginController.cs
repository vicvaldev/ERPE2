using ERPE2.BL.Interfaces.Auth;
using ERPE2.Dto;
using ERPE2.Dto.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ERPE2API.Controllers;

[ApiController]
[Route("api/login")]
public class LoginController : Controller
{
    private readonly ILoginLogic _loginLogic;

    public LoginController(ILoginLogic loginLogic)
    {
        _loginLogic = loginLogic;
    }

    [HttpPost]
    public IActionResult Login(LoginRequest user)
    {
        var login = _loginLogic.Login(user);
        if (login.IsSuccess)
        {
            return Ok(login.Value);
        }
        else
        {
            return Unauthorized(login.Error);
        }
    }
}