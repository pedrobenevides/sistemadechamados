using System.Collections.Generic;

namespace SistemaDeChamados.Domain.Entities
{
    public class Colaborador : Usuario
    {
        public Colaborador(string email, string nome)
            : base(email, nome)
        { }

        protected Colaborador()
        { }

        public long SetorId { get; private set; }
        public virtual Setor Setor { get; private set; }
        public long? PerfilId { get; private set; }
        public virtual IList<Chamado> Chamados { get; set; }

        public void AssociarAoSetor(long setorId)
        {
            SetorId = setorId;
        }

        public void AssociarPerfil(long perfilId)
        {
            PerfilId = perfilId;
        }
    }
}
