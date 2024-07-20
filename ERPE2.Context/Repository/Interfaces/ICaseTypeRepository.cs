using ERPE2.Context.Models;
using ERPE2.Dto;

namespace ERPE2.Context.Repository.Interfaces;

public interface ICaseTypeRepository : IBaseRepository<CaseTypeDto, CaseType>
{
    public List<CaseTypeDto> GetAll();

    public CaseTypeDto Create(CaseTypeDto caseType);

    public bool Delete(CaseTypeDto caseType);
}