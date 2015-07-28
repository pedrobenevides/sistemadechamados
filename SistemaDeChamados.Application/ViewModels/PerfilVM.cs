using System.Collections.Generic;

namespace SistemaDeChamados.Application.ViewModels
{
    public class PerfilVM
    {
        public PerfilVM()
        {
            Acoes = new Dictionary<string, string>
            {
                {"df","dsf"}
            };
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public IDictionary<string, string> Acoes { get; set; }
    }
}
