using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeChamados.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        T Create(T entity);
        IQueryable<T> Obter();
        IQueryable<T> ObterAsNoTracking();
        void Update(T entity);
        void Delete(long id);
        T GetById(long id);
        Task<T> GetByIdAsync(long id);
        void Dispose();
    }
}
