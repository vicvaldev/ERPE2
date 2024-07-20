using System.Collections;
using ERPE2.Context.Models;
using ERPE2.Context.Repository.Interfaces;

namespace ERPE2.Context.Repository.Implementations;

public class E2ContextImplementation : IE2ContextImplementation
{
    private E2DbContext _dbContext = null;

    private Hashtable repositories = new Hashtable();

    public E2ContextImplementation()
    {
        _dbContext = new E2DbContext();
    }

    public IRepository<T> GetRepository<T>() where T : class
    {
        if (!repositories.Contains(typeof(T)))
        {
            repositories.Add(typeof(T), new Repository<T>(_dbContext));
        }
        return (IRepository<T>)repositories[typeof(T)];
    }

    public E2DbContext Context()
    {
        return _dbContext;
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    public void SaveAsync()
    {
        _dbContext.SaveChangesAsync();
    }

    public void CloseAll()
    {
        _dbContext.Dispose();
    }
}