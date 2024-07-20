using ERPE2.Dto;
using ERPE2.Dto.Responses;

namespace ERPE2.BL.Interfaces.Maintainer;

public interface IColorLogic
{
    public Result<List<ColorDto>> GetAll();

    public Result<ColorDto> Create(ColorDto color);

    Result<bool> Delete(ColorDto color);
}