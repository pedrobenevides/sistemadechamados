 using System.IO;

namespace SistemaDeChamados.Application.ViewModels
{
    public class ArquivoVM
    {
        public string Filename { get; set; }
        public Stream Stream { get; set; }
        public int ContentLength { get; set; }
        public string ContentType { get; set; }
    }
}
