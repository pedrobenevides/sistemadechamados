using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Domain.Interfaces.Services
{
    public interface IColaboradorService : IUsuarioService
    {
        Task<IList<Colaborador>> ObterAtivosAsync();
    }
}
