using System.Collections.Generic;
using System.Linq;
using SistemaDeChamados.Domain.DTO;
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

        public IQueryable<Usuario> ObterReadOnly()
        {
            return context.Usuarios.AsNoTracking();
        }

        public UsuarioDTO ObterParaEdicao(long id)
        {
            return context.Usuarios.Where(u => u.Id == id).Select(u => new UsuarioDTO{Email = u.Email, Nome = u.Nome}).FirstOrDefault();
        }
    }
}
