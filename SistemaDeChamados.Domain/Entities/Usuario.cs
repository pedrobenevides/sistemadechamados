using System;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Domain.Entities
{
    public abstract class Usuario
    {
        protected Usuario(string email, string nome)
        {
            Nome = nome;
            Email = email;
            EstaAtivo = true;
            DataDeCriacao = DateTime.Now;
        }

        protected Usuario()
        { }
        
        public long Id { get; private set; }
        public DateTime DataDeCriacao { get; private set; }
        public string Email { get; private set; }
        public string Nome { get; private set; }
        public string Password { get; private set; }
        public bool EstaAtivo { get; private set; }
        
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
    }
}
