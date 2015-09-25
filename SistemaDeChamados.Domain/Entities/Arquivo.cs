 using System;
 using System.IO;

namespace SistemaDeChamados.Domain.Entities
{
    public class Arquivo
    {
        public long Id { get; set; }
        public string Filename { get; set; }
        public int Tamanho { get; set; }
        public string ContentType { get; set; }
        public DateTime? UltimaVisualizacao { get; set; }
        public string Caminho { get; set; }
        public long ChamadoId { get; set; }
        public Stream Stream { get; set; } //[NotMapped] adicionado via Fluent.
    }
}
