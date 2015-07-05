using System.Linq;

namespace SistemaDeChamados.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        void Create(T entity);
        IQueryable<T> Retrieve();
        void Update(T entity);
        void Delete(long id);
        T GetById(long id);
        void Dispose();
    }
}
