 using System.Collections.Generic;
 using System.Threading.Tasks;
 using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Domain.Interfaces.Services
{
    public interface IAnalistaService : IServiceBase<Analista>
    {
        string ObterNomePorId(long id);
        Task<IEnumerable<Analista>> ObterAsync();
    }
}
