namespace SistemaDeChamados.Application.ViewModels.Api.Chamados
{
    public class AlterarStatusVM
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public string Status { get; set; }
    }
}
