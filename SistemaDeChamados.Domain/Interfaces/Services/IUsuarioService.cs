using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.DTO;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Usuario ObterUsuarioComCredenciaisValidas(string login, string senha);
        IQueryable<Usuario> ObterReadOnly();
        Task<IEnumerable<Usuario>> ObterAsync();
        UsuarioDTO ObterParaEdicao(long id);
    }
}
