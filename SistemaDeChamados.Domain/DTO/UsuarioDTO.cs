namespace SistemaDeChamados.Domain.DTO
{
    public class UsuarioDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }

    public class UsuarioSenhaDTO
    {
        public long Id { get; set; }
        public string Password { get; set; }
    }
}
