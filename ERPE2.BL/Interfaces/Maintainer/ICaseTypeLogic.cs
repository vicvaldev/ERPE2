using ERPE2.Dto;
using ERPE2.Dto.Responses;

namespace ERPE2.BL.Interfaces.Maintainer;

public interface ICaseTypeLogic
{
    public Result<List<CaseTypeDto>> GetAll();

    public Result<CaseTypeDto> Create(CaseTypeDto caseType);

    public Result<bool> Delete(CaseTypeDto caseType);
}