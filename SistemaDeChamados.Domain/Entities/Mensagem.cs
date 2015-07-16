using System;

namespace SistemaDeChamados.Domain.Entities
{
    public class Mensagem
    {
        public Mensagem(string texto, long usuarioId, long chamadoId)
        {
            Texto = texto;
            DataDeCriacao = DateTime.Now;
            UsuarioId = usuarioId;
            ChamadoId = chamadoId;
        }

        protected Mensagem()
        { }

        public long Id { get; private set; }
        public DateTime DataDeCriacao { get; private set; }
        public string Texto { get; private set; }
        public long ChamadoId { get; private set; }
        public long UsuarioId { get; private set; }
        public virtual Chamado Chamado { get; private set; }
    }
}
