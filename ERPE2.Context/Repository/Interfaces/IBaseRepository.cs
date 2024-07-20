namespace ERPE2.Context.Repository.Interfaces;

public interface IBaseRepository<TDto, TEntity> where TEntity : class where TDto : class
{
    TDto ToDto(TEntity entity);
    TEntity ToEntity(TDto dto);
}