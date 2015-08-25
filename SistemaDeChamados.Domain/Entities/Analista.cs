using System.Collections.Generic;

namespace SistemaDeChamados.Domain.Entities
{
    public class Analista : Usuario
    {
        public Analista(string email, string nome) : base(email, nome)
        {
            Categorias = new List<Categoria>();
        }

        protected Analista()
        { }

        public virtual IList<Categoria> Categorias { get; set; }

        public void AssociarCategoria(Categoria categoria)
        {
            Categorias.Add(categoria);
        }
    }
}
