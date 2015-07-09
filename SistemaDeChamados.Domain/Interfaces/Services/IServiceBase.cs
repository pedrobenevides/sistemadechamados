using System.Linq;

namespace SistemaDeChamados.Domain.Interfaces.Services
{
    public interface IServiceBase<T> where T : class
    {
        T Create(T entity);
        IQueryable<T> Retrieve();
        void Update(T entity);
        void Delete(long id);
        T GetById(long id);
    }
}
