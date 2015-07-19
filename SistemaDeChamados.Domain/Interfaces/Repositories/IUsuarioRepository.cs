using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.DTO;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario ObterPorEmail(string email);
        IQueryable<Usuario> ObterReadOnly();
        Task<IEnumerable<Usuario>> ObterAsync();
        UsuarioDTO ObterParaEdicao(long id);
    }
}
