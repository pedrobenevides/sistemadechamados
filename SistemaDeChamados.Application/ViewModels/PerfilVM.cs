using System.Collections.Generic;

namespace SistemaDeChamados.Application.ViewModels
{
    public class PerfilVM
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public IList<string> Acoes { get; set; }
    }
}
