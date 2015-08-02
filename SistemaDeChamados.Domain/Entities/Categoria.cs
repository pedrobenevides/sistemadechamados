namespace SistemaDeChamados.Domain.Entities
{
    public class Categoria
    {
        protected Categoria()
        { }

        public Categoria(string nome, long setorId)
        {
            Nome = nome;
            SetorId = setorId;
        }
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public long SetorId { get; private set; }

        public void AssociarAoSetor(long setorId)
        {
            SetorId = setorId;
        }
    }
}