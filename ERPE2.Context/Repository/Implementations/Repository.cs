using System.Linq.Expressions;
using ERPE2.Context.Models;
using ERPE2.Context.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ERPE2.Context.Repository.Implementations;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly E2DbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(E2DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

        /// <summary>
        /// Use for made a Select Query
        /// <param name="filter"> Use for add filters conditionals Ex: x.Id == Id</param>
        /// <param name="orderBy"> Order By, desc or asc</param>
        /// <param name="includeProperties"> Use name of model, for get the data, Ex: Transportation, Exporter, ...</param>
        /// <returns>The expected result of query in SQL</returns>
        /// </summary>
        public virtual IEnumerable<TEntity> Get
        (
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = ""
        )
        {
            try
            {
                IQueryable<TEntity> query = _dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split(new char[]
                             {
                                 ','
                             }
                             , StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return orderBy(query)
                        .ToList();
                }
                else
                {
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Use for made a pagination to front
        /// </summary>
        /// <param name="filter"> Use for add filters conditionals Ex: x.Id == Id</param>
        /// <param name="orderBy"> Order By, desc or asc</param>
        /// <param name="includeProperties"> Use name of model, for get the data, Ex: "Transportation, Exporter, ..."</param>
        /// <returns>The expected result of query in SQL</returns>
        public virtual IEnumerable<TEntity> Get
        (
            out int total,
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = ""
        )
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty
                     in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            total = query.Count();


            return query.ToList();
        }


        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual EntityEntry Insert(TEntity entity)
        {
            return _dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete)
                    .State
                == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }

            _dbSet.Remove(entityToDelete);
        }

        public virtual bool Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);

            var properties =
                entityToUpdate
                    .GetType()
                    .GetProperties()
                    .Where(propertyInfo =>
                        propertyInfo.GetValue(entityToUpdate, null) != null
                        && !propertyInfo.GetGetMethod()
                            .IsVirtual).ToList();

            foreach (var propertyInfo in properties)
            {
                if (propertyInfo.Name != "Id" && propertyInfo.Name != "Rut" && propertyInfo.Name != "Csp")
                {
                    _context.Entry(entityToUpdate)
                        .Property(propertyInfo.Name)
                        .IsModified = true;
                }
            }

            var result = _context.SaveChanges();
            return result > 0;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual int CountTotal()
        {
            return _dbSet.Count();
        }

        public virtual IEnumerable<TEntity> GetAll(string includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (var includeProperty in includeProperties.Split(new char[]
                         {
                             ','
                         }
                         , StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query.ToList();
        }
}