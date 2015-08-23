using System.Data.Entity;
using System.Linq;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Repositories;

namespace SistemaDeChamados.Infra.Data.Repositories
{
    public class PerfilRepository : RepositoryBase<Perfil>, IPerfilRepository
    {
        private IDbSet<Perfil> Perfis { get { return context.Perfis; } } 

        public Perfil ObterPeloIdDoUsuario(long id)
        {
            return Perfis.FirstOrDefault(p => p.Colaboradores.Any(u => u.Id == id));
        }
    }
}
