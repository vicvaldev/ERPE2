using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ERPE2.Context.Repository.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    IEnumerable<TEntity> Get
    (
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = ""
    );

    EntityEntry Insert(TEntity entity);
    void Delete(TEntity entityToDelete);
}