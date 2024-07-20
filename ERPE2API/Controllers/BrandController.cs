using ERPE2.BL.Interfaces.Maintainer;
using ERPE2.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERPE2API.Controllers;

[ApiController]
[Route("api/brand")]

public class BrandController : Controller
{
    private readonly IBrandLogic _brandLogic;

    public BrandController(IBrandLogic brandLogic)
    {
        _brandLogic = brandLogic;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        var brandList = _brandLogic.GetAll();
        if (brandList.IsSuccess)
        {
            return Ok(brandList.Value);
        }
        
        return BadRequest(brandList.Error);
    }
    
    [HttpPost]
    public IActionResult Create([FromBody] BrandDto brand)
    {
        var newBrand = _brandLogic.Create(brand);
        if (newBrand.IsSuccess)
        {
            return Ok(newBrand.Value);
        }
        
        return BadRequest(newBrand.Error);
    }
    
    [HttpDelete]
    public IActionResult Delete([FromBody] BrandDto brand)
    {
        var result = _brandLogic.Delete(brand);
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        
        return BadRequest(result.Error);
    }
}