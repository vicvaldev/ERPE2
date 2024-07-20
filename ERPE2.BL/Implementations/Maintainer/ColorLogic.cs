using ERPE2.BL.Interfaces.Maintainer;
using ERPE2.Context.Models;
using ERPE2.Context.Repository.Interfaces;
using ERPE2.Dto;
using ERPE2.Dto.Responses;

namespace ERPE2.BL.Implementations.Maintainer;

public class ColorLogic : IColorLogic
{
    private readonly IColorRepository _colorRepository;

    public ColorLogic(IColorRepository colorRepository)
    {
        _colorRepository = colorRepository;
    }

    public Result<List<ColorDto>> GetAll()
    {
        var colorList = _colorRepository.GetAll();
        if (colorList.Count() > 0)
        {
            return Result<List<ColorDto>>.Success(colorList);
        }
        return Result<List<ColorDto>>.Failure("No existen datos para colores");
    }

    public Result<ColorDto> Create(ColorDto color)
    {
        var newColor = _colorRepository.Create(color);
        if (newColor != null)
        {
            return Result<ColorDto>.Success(color);
        }
        return Result<ColorDto>.Failure("Error al crear el recurso de color");
    }
    
    public Result<bool> Delete(ColorDto color)
    {
        var deletedColor = _colorRepository.Delete(color);
        
        if (deletedColor)
        {
            return Result<bool>.Success(true);
        }
        
        return Result<bool>.Failure("Error al eliminar el recurso de color");
    }
}