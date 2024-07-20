using ERPE2.Context.Models;
using ERPE2.Context.Repository.Interfaces;
using ERPE2.Dto;

namespace ERPE2.Context.Repository.Implementations;

public class BrandRepository : IBaseRepository<BrandDto, Brand>, IBrandRepository
{
    
    private readonly IE2ContextImplementation _context;

    public BrandRepository(IE2ContextImplementation context)
    {
        _context = context;
    }

    public List<BrandDto> GetAll()
    {
        var brandContext = _context.GetRepository<Brand>();
        var brandList  = brandContext.Get();
        return brandList.Select(x => ToDto(x)).ToList();
    }

    public BrandDto Create(BrandDto brand)
    {
        var brandContext = _context.GetRepository<Brand>();
        var brandEntity = ToEntity(brand);
        brandContext.Insert(brandEntity);
        _context.Save();
        return brand;
    }

    public bool Delete(BrandDto brand)
    {
        var brandContext = _context.GetRepository<Brand>();
        var brandEntity = ToEntity(brand);
        brandContext.Delete(brandEntity);
        _context.Save();
        return true;
    }
    
    public BrandDto ToDto(Brand entity)
    {
        if (entity == null) return null;
        return new BrandDto()
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }

    public Brand ToEntity(BrandDto dto)
    {
        if (dto == null) return null;
        return new Brand()
        {
            Id = dto.Id,
            Name = dto.Name
        };
    }
}