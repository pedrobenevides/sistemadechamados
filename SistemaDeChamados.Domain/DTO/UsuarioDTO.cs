namespace SistemaDeChamados.Domain.DTO
{
    public class UsuarioDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public long SetorId { get; set; }
        public long? PerfilId { get; set; }
        public bool EstaAtivo { get; set; }
    }

    public class UsuarioSenhaDTO
    {
        public long Id { get; set; }
        public string Password { get; set; }
    }
}
