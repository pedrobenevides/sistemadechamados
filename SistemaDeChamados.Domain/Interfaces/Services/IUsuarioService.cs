using System.Collections.Generic;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Usuario ValidaSenhaInformada(string login, string senha);
        IEnumerable<Usuario> ObterReadOnly();
    }
}
