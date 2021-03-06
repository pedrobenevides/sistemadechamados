﻿using System.Linq;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Repositories;

namespace SistemaDeChamados.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public Usuario ObterAtivoPorEmail(string email)
        {
            return context.Usuarios.FirstOrDefault(u => u.Email == email && u.EstaAtivo);
        }

        public IQueryable<Usuario> ObterReadOnly()
        {
            return context.Usuarios.AsNoTracking();
        }

        public Usuario GetByIdAsNoTracking(long id)
        {
            return context.Usuarios.AsNoTracking().FirstOrDefault(u => u.Id == id);
        }
    }
}
