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
            Colaboradores = new List<Colaborador>();
        }

        public long Id { get; private set; }
        public string Nome { get; private set; }
        public virtual IList<Colaborador> Colaboradores { get; private set; }
        public virtual IList<Categoria> Categorias { get; private set; }

        public void AdicionarColaborador(Colaborador colaborador)
        {
            Colaboradores.Add(colaborador);
        }

        public void RemoverColaborador(long usuarioId)
        {
            var colaborador = Colaboradores.FirstOrDefault(u => u.Id == usuarioId);

            if (colaborador == null)
                throw new UsuarioNaoEncontradoException();

            Colaboradores.Remove(colaborador);
        }
    }
}
