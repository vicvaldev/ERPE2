using ERPE2.Context.Repository.Interfaces;

namespace ERPE2.Context.Repository.Implementations;

public abstract class BaseRepository <TDto, TEntity> : IBaseRepository<TDto, TEntity> where TEntity : class where TDto : class 
{
    public abstract TDto ToDto(TEntity entity);
    public abstract TEntity ToEntity(TDto dto);
}