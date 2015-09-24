using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.DTO;

namespace SistemaDeChamados.Domain.Interfaces.Repositories
{
    public interface IColaboradorRepository : IUsuarioRepository
    {
        Task<IList<ColaboradorDTO>> ObterAsync();
        Task<IList<ColaboradorDTO>> ObterAtivosAsync();
        UsuarioDTO ObterParaEdicao(long id);
        string ObterNomeDoColaboradorPorId(long id);
        Task<IEnumerable<ColaboradorDTO>> ObterAsyncPaginado(int pagina, int porPagina);
    }
}
