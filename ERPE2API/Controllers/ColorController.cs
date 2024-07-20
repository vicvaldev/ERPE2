using ERPE2.BL.Interfaces.Maintainer;
using ERPE2.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERPE2API.Controllers;

[ApiController]
[Route("api/color")]

public class ColorController : Controller
{
    private readonly IColorLogic _colorLogic;

    public ColorController(IColorLogic colorLogic)
    {
        _colorLogic = colorLogic;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        var colorList = _colorLogic.GetAll();
        if (colorList.IsSuccess)
        {
            return Ok(colorList.Value);
        }
        
        return BadRequest(colorList.Error);
    }
    
    [HttpPost]
    public IActionResult Create([FromBody] ColorDto color)
    {
        var newColor = _colorLogic.Create(color);
        if (newColor.IsSuccess)
        {
            return Ok(newColor.Value);
        }
        
        return BadRequest(newColor.Error);
    }
    
    [HttpDelete]
    public IActionResult Delete([FromBody] ColorDto color)
    {
        var result = _colorLogic.Delete(color);
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        
        return BadRequest(result.Error);
    }
}