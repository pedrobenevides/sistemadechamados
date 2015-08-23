using System.Linq;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Repositories;

namespace SistemaDeChamados.Infra.Data.Repositories
{
    public class SetorRepository : RepositoryBase<Setor>, ISetorRepository
    {
        public Setor ObterPorUsuarioId(long usuarioId)
        {
            return context.Setores.FirstOrDefault(s => s.Colaboradores.Any(u => u.Id == usuarioId));
        }
    }
}
