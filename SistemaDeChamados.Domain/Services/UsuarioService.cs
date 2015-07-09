using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Repositories;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IRepositoryBase<Usuario> usuarioRepository;
        private readonly ICriptografadorDeSenha criptografadorDeSenha;

        public UsuarioService(IRepositoryBase<Usuario> usuarioRepository, ICriptografadorDeSenha criptografadorDeSenha) 
            : base(usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.criptografadorDeSenha = criptografadorDeSenha;
        }

        public override void Create(Usuario entity)
        {
            entity.EstaAtivo = true;
            entity.Password = criptografadorDeSenha.CriptografarSenha(entity.Password);

            base.Create(entity);
        }
    }
}
