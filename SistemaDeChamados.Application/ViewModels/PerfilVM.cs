using System.Collections.Generic;
using SistemaDeChamados.Domain.VO;

namespace SistemaDeChamados.Application.ViewModels
{
    public class PerfilVM
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public IList<AcessoVM> Acoes { get; set; }
    }

    public class AcessoVM
    {
        public string Chave { get; set; }
        public string Descricao { get; set; }
        public bool Selecionado { get; set; }
    }
}
