using ERPE2.Context.Models;
using ERPE2.Context.Repository.Interfaces;
using ERPE2.Dto;

namespace ERPE2.Context.Repository.Implementations;

public class ColorRepository : IBaseRepository<ColorDto, Color>, IColorRepository
{
    private readonly IE2ContextImplementation _context;

    public ColorRepository(IE2ContextImplementation context)
    {
        _context = context;
    }

    public List<ColorDto> GetAll()
    {
        var colorContext = _context.GetRepository<Color>();
        var colorList  = colorContext.Get();
        return colorList.Select(x => ToDto(x)).ToList();
    }

    public ColorDto Create(ColorDto color)
    {
        var colorContext = _context.GetRepository<Color>();
        var colorEntity = ToEntity(color);
        colorContext.Insert(colorEntity);
        _context.Save();
        return color;
    }

    public bool Delete(ColorDto color)
    {
        var colorContext = _context.GetRepository<Color>();
        var colorEntity = ToEntity(color);
        colorContext.Delete(colorEntity);
        _context.Save();
        return true;
    }
    
    public ColorDto ToDto(Color entity)
    {
        if (entity == null) return null;
        return new ColorDto()
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }

    public Color ToEntity(ColorDto dto)
    {
        if (dto == null) return null;
        return new Color()
        {
            Id = dto.Id,
            Name = dto.Name
        };
    }
}