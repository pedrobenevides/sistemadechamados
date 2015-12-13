using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Enums;

namespace SistemaDeChamados.Domain.Interfaces.Repositories
{
    public interface IChamadoRepository : IRepositoryBase<Chamado>
    {
        Task<List<Chamado>> Obter5RecentesPorUsuarioAsync(long usuarioId);
        Task<List<Chamado>> Obter5EmAbertoAsync(long usuarioId);
        void AlterarStatus(Chamado chamado, StatusDoChamado statusNovo);
        Task<Chamado> CreateAndCommitAsync(Chamado chamado);
        long ObterIdDoAnalistaDesseChamado(long chamadoId);
    }
}
