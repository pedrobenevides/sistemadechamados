 using System.Collections.Generic;
 using System.Threading.Tasks;
 using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Domain.Interfaces.Services
{
    public interface IArquivoService : IServiceBase<Arquivo>
    {
        Task SalvarArquivosFisicos(IList<Arquivo> arquivosStreams, long chamadoId);
    }
}
