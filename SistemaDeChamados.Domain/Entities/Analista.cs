namespace SistemaDeChamados.Domain.Entities
{
    public class Analista : Usuario
    {
        public Analista(string email, string nome) : base(email, nome)
        { }

        protected Analista()
        { }

        public long CategoriaId { get; private set; }

        public void AssociarCategoria(long categoriaId)
        {
            CategoriaId = categoriaId;
        }
    }
}
