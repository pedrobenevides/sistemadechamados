using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Domain.Interfaces.Repositories
{
    public interface IColaboradorRepository : IUsuarioRepository
    {
        Task<IList<Colaborador>> ObterAtivosAsync();
    }
}
