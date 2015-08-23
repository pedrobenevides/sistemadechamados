using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeChamados.Application.ViewModels;

namespace SistemaDeChamados.Application.Interface
{
    public interface IColaboradorAppService : IUsuarioAppService
    {
        Task<IList<UsuarioVM>> ObterAtivosAsync();
    }
}
