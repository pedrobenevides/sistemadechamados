using System.Collections.Generic;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Exceptions;
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
            entity.EstaAtivo = true;
            entity.Password = criptografadorDeSenha.CriptografarSenha(entity.Password);

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

        public IEnumerable<Usuario> ObterReadOnly()
        {
            return usuarioRepository.ObterReadOnly();
        }
    }
}
