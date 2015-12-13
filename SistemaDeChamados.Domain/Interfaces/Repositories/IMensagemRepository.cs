using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Domain.Interfaces.Repositories
{
    public interface IMensagemRepository : IRepositoryBase<Mensagem>
    {
        Task<IEnumerable<Mensagem>> Obter5UltimasAsync(long chamadoId);
        IEnumerable<Mensagem> Obter5Ultimas(long chamadoId);
        int ObterNumeroDeMensagensNaoLidas(long usuarioId);
    }
}
