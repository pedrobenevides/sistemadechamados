using System.Linq;
using SistemaDeChamados.Domain.DTO;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Usuario ObterUsuarioComCredenciaisValidas(string login, string senha);
        IQueryable<Usuario> ObterReadOnly();
        UsuarioDTO ObterParaEdicao(long id);
        string ObterPasswordPorId(long id);

    }
}
