namespace SistemaDeChamados.Application.ViewModels
{
    public class MensagemVM
    {
        public long Id { get; set; }
        public string DataDeCriacao { get; set; }
        public string Texto { get; set; }
        public long ChamadoId { get; set; }
        public long UsuarioId { get; set; }
        public string NomeUsuario { get; set; }
        public bool FoiLida { get; set; }
    }
}
