using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Repositories;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IRepositoryBase<Usuario> usuarioRepository;

        public UsuarioService(IRepositoryBase<Usuario> usuarioRepository) 
            : base(usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }
    }
}
