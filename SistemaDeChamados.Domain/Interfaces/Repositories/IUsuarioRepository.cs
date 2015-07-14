using System.Collections.Generic;
using SistemaDeChamados.Domain.DTO;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario ObterPorEmail(string email);
        IEnumerable<Usuario> ObterReadOnly();
        UsuarioDTO ObterParaEdicao(long id);
    }
}
