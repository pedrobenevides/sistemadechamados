namespace SistemaDeChamados.Domain.Entities
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
        public bool EstaAtivo { get; set; }
    }
}
