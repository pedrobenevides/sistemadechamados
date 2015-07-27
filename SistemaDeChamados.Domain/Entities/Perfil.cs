using System.Collections.Generic;
using System.Linq;
using SistemaDeChamados.Domain.Exceptions;

namespace SistemaDeChamados.Domain.Entities
{
    public class Perfil
    {
        protected Perfil()
        { }

        public Perfil(string nome)
        {
            Nome = nome;
        }

        public long Id { get; private set; }
        public string Nome { get; private set; }
        public string Acoes { get; private set; }
        public IList<Usuario> Usuarios { get; private set; }

        public void AdicionarAcao(string acao)
        {
            if (!acao.EndsWith(";"))
                throw new ChamadosException("Ação está formatada incorretamente.");
                
            Acoes += acao;
        }

        public IEnumerable<string> ObterAcoesFormatadas()
        {
            return string.IsNullOrEmpty(Acoes) ? new List<string>() : Acoes.Split(';').Where(a => a != "").ToList();
        }
    }
}
