using System.Threading.Tasks;

namespace SistemaDeChamados.Infra.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
