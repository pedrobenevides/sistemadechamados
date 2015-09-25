 using System.IO;

namespace SistemaDeChamados.Domain.DTO
{
    public class ArquivoDTO
    {
        public string Filename { get; set; }
        public Stream Stream { get; set; }
        public int ContentLength { get; set; }
        public string ContentType { get; set; }
    }
}
