using ERPE2.BL.Interfaces.Maintainer;
using ERPE2.Context.Repository.Interfaces;
using ERPE2.Dto;
using ERPE2.Dto.Responses;

namespace ERPE2.BL.Implementations.Maintainer;

public class CaseTypeLogic : ICaseTypeLogic
{
    private readonly ICaseTypeRepository _caseTypeRepository;

    public CaseTypeLogic(ICaseTypeRepository caseTypeRepository)
    {
        _caseTypeRepository = caseTypeRepository;
    }
    
    public Result<List<CaseTypeDto>> GetAll()
    {
        var caseTypeList = _caseTypeRepository.GetAll();
        if (caseTypeList.Count() > 0)
        {
            return Result<List<CaseTypeDto>>.Success(caseTypeList);
        }
        return Result<List<CaseTypeDto>>.Failure("No existen datos para caseTypees");
    }

    public Result<CaseTypeDto> Create(CaseTypeDto caseType)
    {
        var newCaseType = _caseTypeRepository.Create(caseType);
        if (newCaseType != null)
        {
            return Result<CaseTypeDto>.Success(caseType);
        }
        return Result<CaseTypeDto>.Failure("Error al crear el recurso de caseType");
    }
    
    public Result<bool> Delete(CaseTypeDto caseType)
    {
        var deletedCaseType = _caseTypeRepository.Delete(caseType);
        
        if (deletedCaseType)
        {
            return Result<bool>.Success(true);
        }
        
        return Result<bool>.Failure("Error al eliminar el recurso de caseType");
    }
}