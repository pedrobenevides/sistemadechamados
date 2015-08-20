using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Repositories;

namespace SistemaDeChamados.Infra.Data.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        private DbSet<Categoria> Categorias { get { return context.Categorias; } }

        public IEnumerable<Categoria> ObterPorSetor(long setorId)
        {
            return Categorias.Where(c => c.SetorId == setorId);
        }

        public async Task<IEnumerable<Categoria>> ObterPorSetorAsync(long setorId)
        {
            return await Categorias.Where(c => c.SetorId == setorId).ToListAsync();
        }
    }
}
