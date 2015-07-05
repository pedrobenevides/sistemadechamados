using System;

namespace SistemaDeChamados.Application.ViewModels
{
    public class MensagemVM
    {
        public long Id { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public string Texto { get; set; }
        public long ChamadoId { get; set; }
        public long UsuarioId { get; set; }
    }
}
