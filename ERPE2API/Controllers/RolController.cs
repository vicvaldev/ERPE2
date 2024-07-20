using Microsoft.AspNetCore.Mvc;

namespace ERPE2API.Controllers;
[ApiController]
[Route("api/rol")]
public class RolController : Controller
{
    // GET
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}