using System.Collections.Generic;
using System.Linq;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Repositories;

namespace SistemaDeChamados.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public Usuario ObterPorEmail(string email)
        {
            return context.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public IEnumerable<Usuario> ObterReadOnly()
        {
            return context.Usuarios.AsNoTracking().ToList();
        }
    }
}
