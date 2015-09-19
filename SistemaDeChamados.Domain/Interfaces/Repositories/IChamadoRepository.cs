using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Domain.Interfaces.Repositories
{
    public interface IChamadoRepository : IRepositoryBase<Chamado>
    {
        Task<List<Chamado>> Obter5RecentesPorUsuarioAsync(long usuarioId);
    }
}
