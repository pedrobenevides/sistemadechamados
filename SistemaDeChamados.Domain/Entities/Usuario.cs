using System.Collections.Generic;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Domain.Entities
{
    public class Usuario
    {
        public Usuario(string email, string nome)
        {
            Nome = nome;
            Email = email;
            EstaAtivo = true;
        }

        protected Usuario()
        { }

        public long Id { get; private set; }
        public string Email { get; private set; }
        public string Nome { get; private set; }
        public string Password { get; private set; }
        public bool EstaAtivo { get; private set; }
        public long SetorId { get; private set; }
        public virtual Setor Setor { get; private set; }
        public long? PerfilId { get; private set; }

        public void DefinirPassword(string password, ICriptografadorDeSenha criptografadorDeSenha)
        {
            Password = criptografadorDeSenha.CriptografarSenha(password);
            EstaAtivo = true;
        }

        public void AtivarUsuario()
        {
            EstaAtivo = true;
        }
        
        public void DesativarUsuario()
        {
            EstaAtivo = false;
        }

        public void AssociarAoSetor(long setorId)
        {
            SetorId = setorId;
        }

        public void AssociarPerfil(long perfilId)
        {
            PerfilId = perfilId;
        }
    }
}
