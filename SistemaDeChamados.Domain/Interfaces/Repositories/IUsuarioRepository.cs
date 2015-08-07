using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.DTO;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario ObterAtivoPorEmail(string email);
        IQueryable<Usuario> ObterReadOnly();
        Task<IList<Usuario>> ObterAtivosAsync();
        UsuarioDTO ObterParaEdicao(long id);
    }
}
