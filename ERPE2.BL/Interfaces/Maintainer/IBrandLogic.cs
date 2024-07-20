using ERPE2.Dto;
using ERPE2.Dto.Responses;

namespace ERPE2.BL.Interfaces.Maintainer;

public interface IBrandLogic
{
    public Result<List<BrandDto>> GetAll();

    public Result<BrandDto> Create(BrandDto brand);

    public Result<bool> Delete(BrandDto brand);
}