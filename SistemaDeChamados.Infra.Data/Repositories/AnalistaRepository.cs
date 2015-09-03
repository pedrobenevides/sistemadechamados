using System.Data.Entity;
using System.Linq;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Repositories;

namespace SistemaDeChamados.Infra.Data.Repositories
{
    public class AnalistaRepository : RepositoryBase<Analista>, IAnalistaRepository
    {
        protected IDbSet<Analista> Analistas { get { return context.Analistas; } }

        public string ObterNomePorId(long id)
        {
            return Analistas.Where(c => c.Id == id).Select(c => c.Nome).FirstOrDefault();
        }
    }
}
