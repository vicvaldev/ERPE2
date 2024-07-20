using ERPE2.Context.Models;
using ERPE2.Dto;

namespace ERPE2.Context.Repository.Interfaces;

public interface IColorRepository : IBaseRepository<ColorDto, Color>
{
    List<ColorDto> GetAll();
    ColorDto Create(ColorDto color);
    bool Delete(ColorDto color);
}