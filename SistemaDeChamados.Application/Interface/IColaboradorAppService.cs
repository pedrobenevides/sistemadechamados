using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeChamados.Application.ViewModels;

namespace SistemaDeChamados.Application.Interface
{
    public interface IColaboradorAppService : IUsuarioAppService
    {
        IList<ColaboradorVM> Obter();
        Task<IList<ColaboradorVM>> ObterAsync();
        Task<IList<ColaboradorVM>> ObterAtivosAsync();
        void Create(ColaboradorVM colaboradorVM);
        void Update(ColaboradorEdicaoVM colaboradorVM);
        ColaboradorEdicaoVM ObterParaEdicao(long id);
        string ObterNomeDoColaboradorPorId(long id);
        Task<IEnumerable<ColaboradorVM>> ObterAsyncPaginado(int pagina, int porPagina);

    }
}
