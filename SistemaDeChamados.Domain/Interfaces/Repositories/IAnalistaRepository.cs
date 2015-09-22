 using System.Collections.Generic;
 using System.Threading.Tasks;
 using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Domain.Interfaces.Repositories
{
    public interface IAnalistaRepository : IRepositoryBase<Analista>
    {
        string ObterNomePorId(long id);
        Task<IEnumerable<Analista>> ObterAsync();
    }
}
