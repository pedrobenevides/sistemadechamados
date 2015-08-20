using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository : IRepositoryBase<Categoria>
    {
        IEnumerable<Categoria> ObterPorSetor(long setorId);
        Task<IEnumerable<Categoria>> ObterPorSetorAsync(long setorId);
    }
}
