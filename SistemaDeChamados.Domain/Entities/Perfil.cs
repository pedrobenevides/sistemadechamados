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
        public string Acessos { get; private set; }
        public IList<Usuario> Usuarios { get; private set; }

        public void AdicionarAcesso(string acesso)
        {
            if (!acesso.EndsWith(";"))
                throw new ChamadosException("Ação está formatada incorretamente.");
                
            Acessos += acesso;
        }

        public IEnumerable<string> ObterAcessosFormatados()
        {
            return string.IsNullOrEmpty(Acessos) ? new List<string>() : Acessos.Split(';').Where(a => a != "").ToList();
        }
    }
}
