using ERPE2.Context.Models;
using ERPE2.Context.Repository.Interfaces;
using ERPE2.Dto;

namespace ERPE2.Context.Repository.Implementations;

public class CaseTypeRepository : IBaseRepository<CaseTypeDto, CaseType>, ICaseTypeRepository
{
    
    private readonly IE2ContextImplementation _context;

    public CaseTypeRepository(IE2ContextImplementation context)
    {
        _context = context;
    }

    public List<CaseTypeDto> GetAll()
    {
        var caseTypeContext = _context.GetRepository<CaseType>();
        var caseTypeList  = caseTypeContext.Get();
        return caseTypeList.Select(x => ToDto(x)).ToList();
    }

    public CaseTypeDto Create(CaseTypeDto caseType)
    {
        var caseTypeContext = _context.GetRepository<CaseType>();
        var caseTypeEntity = ToEntity(caseType);
        caseTypeContext.Insert(caseTypeEntity);
        _context.Save();
        return caseType;
    }

    public bool Delete(CaseTypeDto caseType)
    {
        var caseTypeContext = _context.GetRepository<CaseType>();
        var caseTypeEntity = ToEntity(caseType);
        caseTypeContext.Delete(caseTypeEntity);
        _context.Save();
        return true;
    }
    
    public CaseTypeDto ToDto(CaseType entity)
    {
        if (entity == null) return null;
        return new CaseTypeDto()
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }

    public CaseType ToEntity(CaseTypeDto dto)
    {
        if (dto == null) return null;
        return new CaseType()
        {
            Id = dto.Id,
            Name = dto.Name
        };
    }
}