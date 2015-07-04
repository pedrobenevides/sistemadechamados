using System;

namespace SistemaDeChamados.Domain.Entities
{
    public class Mensagem
    {
        public long Id { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public string Texto { get; set; }
        public long ChamadoId { get; set; }
        public long UsuarioId { get; set; }
        public virtual Chamado Chamado { get; set; }
    }
}
