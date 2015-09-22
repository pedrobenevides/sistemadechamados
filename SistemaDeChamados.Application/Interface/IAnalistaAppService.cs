 using System.Collections.Generic;
 using System.Threading.Tasks;
 using SistemaDeChamados.Application.ViewModels;
 using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Application.Interface
{
    public interface IAnalistaAppService : IAppService
    {
        string ObterNomePorId(long id);
        Task<IEnumerable<AnalistaVM>> ObterAsync();
    }
}
