using ERPE2.Context.Models;

namespace ERPE2.Context.Repository.Interfaces;

public interface IE2ContextImplementation
{
    IRepository<T> GetRepository<T>() where T : class;
    E2DbContext Context();
    void Save();
    void SaveAsync();
    void CloseAll();
}