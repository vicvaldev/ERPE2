using ERPE2.BL.Interfaces.Maintainer;
using ERPE2.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ERPE2API.Controllers;

[ApiController]
[Route("api/caseType")]
public class CaseTypeController : Controller
{
    private readonly ICaseTypeLogic _caseTypeLogic;

    public CaseTypeController(ICaseTypeLogic caseTypeLogic)
    {
        _caseTypeLogic = caseTypeLogic;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        var caseTypeList = _caseTypeLogic.GetAll();
        if (caseTypeList.IsSuccess)
        {
            return Ok(caseTypeList.Value);
        }
        
        return BadRequest(caseTypeList.Error);
    }
    
    [HttpPost]
    public IActionResult Create([FromBody] CaseTypeDto caseType)
    {
        var newCaseType = _caseTypeLogic.Create(caseType);
        if (newCaseType.IsSuccess)
        {
            return Ok(newCaseType.Value);
        }
        
        return BadRequest(newCaseType.Error);
    }
    
    [HttpDelete]
    public IActionResult Delete([FromBody] CaseTypeDto caseType)
    {
        var result = _caseTypeLogic.Delete(caseType);
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        
        return BadRequest(result.Error);
    }
}