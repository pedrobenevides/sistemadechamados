using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.DTO;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Domain.Interfaces.Repositories
{
    public interface IColaboradorRepository : IUsuarioRepository
    {
        Task<IList<Colaborador>> ObterAsync();
        Task<IList<Colaborador>> ObterAtivosAsync();
        UsuarioDTO ObterParaEdicao(long id);
    }
}
