using ERPE2.Context.Models;
using ERPE2.Dto;

namespace ERPE2.Context.Repository.Interfaces;

public interface IBrandRepository : IBaseRepository<BrandDto, Brand>
{
    public List<BrandDto> GetAll();

    public BrandDto Create(BrandDto brand);

    public bool Delete(BrandDto brand);
}