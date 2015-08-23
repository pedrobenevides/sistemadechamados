using System.Linq;
using SistemaDeChamados.Domain.DTO;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Usuario ValidaSenhaInformada(string login, string senha);
        IQueryable<Usuario> ObterReadOnly();
        void AlterarStatus(long id);
        void AtualizarSenha(UsuarioSenhaDTO usuario);
    }
}
