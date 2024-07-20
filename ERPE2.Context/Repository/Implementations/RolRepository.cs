using ERPE2.Context.Models;
using ERPE2.Context.Repository.Interfaces;
using ERPE2.Dto;

namespace ERPE2.Context.Repository.Implementations;

public class RolRepository : IBaseRepository<RolDto, Rol>, IRolRepository
{
    public RolDto ToDto(Rol entity)
    {
        if (entity == null) return null;

        return new RolDto()
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }

    public Rol ToEntity(RolDto dto)
    {
        if (dto == null) return null;

        return new Rol()
        {
            Id = dto.Id,
            Name = dto.Name
        };
    }
}