namespace SistemaDeChamados.Domain.DTO
{
    public class ColaboradorDTO
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool EstaAtivo { get; set; }
    }
}
