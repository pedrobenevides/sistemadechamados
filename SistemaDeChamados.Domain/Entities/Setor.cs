using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SistemaDeChamados.Domain.Exceptions.Usuario;

namespace SistemaDeChamados.Domain.Entities
{
    public class Setor
    {
        protected Setor()
        { }

        public Setor(string nome)
        {
            Nome = nome;
            Usuarios = new List<Usuario>();
        }

        public long Id { get; private set; }
        public string Nome { get; private set; }
        public virtual IList<Usuario> Usuarios { get; private set; }

        public void AdicionarUsuario(Usuario usuario)
        {
            Usuarios.Add(usuario);
        }

        public void RemoverUsuario(long usuarioId)
        {
            var usuario = Usuarios.FirstOrDefault(u => u.Id == usuarioId);

            if (usuario == null)
                throw new UsuarioNaoEncontradoException();

            Usuarios.Remove(usuario);
        }
    }
}
