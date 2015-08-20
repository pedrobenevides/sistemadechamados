using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Domain.Interfaces.Services
{
    public interface ICategoriaService : IServiceBase<Categoria>
    {
        IEnumerable<Categoria> ObterPorSetor(long setorId);
        Task<IEnumerable<Categoria>> ObterPorSetorAsync(long setorId);
    }
}
