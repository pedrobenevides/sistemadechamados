using System.Linq;
using SistemaDeChamados.Domain.DTO;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Exceptions;
using SistemaDeChamados.Domain.Exceptions.Usuario;
using SistemaDeChamados.Domain.Interfaces.Repositories;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly ICriptografadorDeSenha criptografadorDeSenha;

        public UsuarioService(IUsuarioRepository usuarioRepository, ICriptografadorDeSenha criptografadorDeSenha) 
            : base(usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.criptografadorDeSenha = criptografadorDeSenha;
        }

        public override Usuario Create(Usuario entity)
        {
            entity.DefinirPassword(entity.Password, criptografadorDeSenha);
            return base.Create(entity);
        }

        public Usuario ValidaSenhaInformada(string login, string senha)
        {
            var usuario = usuarioRepository.ObterPorEmail(login);

            if(usuario == null)
                throw new ServiceException("Não existe Usuário com o login informado.");

            if(criptografadorDeSenha.CriptografarSenha(senha) != usuario.Password)
                throw new ServiceException("Credenciais inválidas");
            
            return usuario;
        }

        public IQueryable<Usuario> ObterReadOnly()
        {
            return usuarioRepository.ObterReadOnly();
        }

        public UsuarioDTO ObterParaEdicao(long id)
        {
            return usuarioRepository.ObterParaEdicao(id);
        }

        public void AlterarStatus(long id)
        {
            var usuario = usuarioRepository.GetById(id);

            if (usuario == null)
                throw new UsuarioNaoEncontradoException();

            if (usuario.EstaAtivo)
                usuario.DesativarUsuario();
            else
                usuario.AtivarUsuario();

            usuarioRepository.Update(usuario);
        }
    }
}
