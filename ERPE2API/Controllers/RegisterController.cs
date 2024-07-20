using ERPE2.BL.Interfaces.Auth;
using ERPE2.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ERPE2API.Controllers;

[ApiController]
[Route("api/register")]
public class RegisterController : Controller
{
    private readonly IRegisterLogic _registerLogic;

    public RegisterController(IRegisterLogic registerLogic)
    {
        _registerLogic = registerLogic;
    }

    [HttpPost]
    public IActionResult Create(UserDto user)
    {
        var newUser = _registerLogic.Create(user);
        if (newUser.IsSuccess)
        {
            return Ok(newUser.Value);
        }
        else
        {
            return BadRequest(newUser.Error);
        }
    }
}