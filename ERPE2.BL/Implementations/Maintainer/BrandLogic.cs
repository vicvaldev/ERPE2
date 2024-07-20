using ERPE2.BL.Interfaces.Maintainer;
using ERPE2.Context.Repository.Interfaces;
using ERPE2.Dto;
using ERPE2.Dto.Responses;

namespace ERPE2.BL.Implementations.Maintainer;

public class BrandLogic : IBrandLogic
{
    private readonly IBrandRepository _brandRepository;

    public BrandLogic(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public Result<List<BrandDto>> GetAll()
    {
        var brandList = _brandRepository.GetAll();
        if (brandList.Count() > 0)
        {
            return Result<List<BrandDto>>.Success(brandList);
        }
        return Result<List<BrandDto>>.Failure("No existen datos para brandes");
    }

    public Result<BrandDto> Create(BrandDto brand)
    {
        var newBrand = _brandRepository.Create(brand);
        if (newBrand != null)
        {
            return Result<BrandDto>.Success(brand);
        }
        return Result<BrandDto>.Failure("Error al crear el recurso de brand");
    }
    
    public Result<bool> Delete(BrandDto brand)
    {
        var deletedBrand = _brandRepository.Delete(brand);
        
        if (deletedBrand)
        {
            return Result<bool>.Success(true);
        }
        
        return Result<bool>.Failure("Error al eliminar el recurso de brand");
    }
}