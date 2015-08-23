using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeChamados.Application.ViewModels;

namespace SistemaDeChamados.Application.Interface
{
    public interface IColaboradorAppService : IUsuarioAppService
    {
        Task<IList<ColaboradorVM>> ObterAsync();
        Task<IList<ColaboradorVM>> ObterAtivosAsync();
        void Create(ColaboradorVM colaboradorVM);
        void Update(ColaboradorEdicaoVM colaboradorVM);
        ColaboradorEdicaoVM ObterParaEdicao(long id);
    }
}
