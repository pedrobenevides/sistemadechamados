using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeChamados.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        T Create(T entity);
        IQueryable<T> Retrieve();
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(long id);
        T GetById(long id);
        void Dispose();
    }
}
