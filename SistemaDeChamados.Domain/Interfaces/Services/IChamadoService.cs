using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Enums;

namespace SistemaDeChamados.Domain.Interfaces.Services
{
    public interface IChamadoService : IServiceBase<Chamado>
    {
        Task<List<Chamado>> Obter5RecentesPorUsuarioAsync(long usuarioId);
        Task<List<Chamado>> Obter5EmAbertoAsync(long usuarioId);
        void AlterarStatus(long chamadoId, long usuarioId, StatusDoChamado statusNovo);
        Task CreateComAnexosAsync(Chamado chamado);
        Task AlterarStatusAsync(long id, long usuarioId, string status);
        long ObterIdDoAnalistaDesseChamado(long chamadoId);
    }
}
