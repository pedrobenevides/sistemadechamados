using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Domain.Interfaces.Services
{
    public interface IMensagemService : IServiceBase<Mensagem>
    {
        Task<IEnumerable<Mensagem>> Obter5UltimasAsync(long chamadoId);
        IEnumerable<Mensagem> Obter5Ultimas(long chamadoId);
        int ObterNumeroDeMensagensNaoLidas(long usuarioId);
    }
}
