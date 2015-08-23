using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Repositories;

namespace SistemaDeChamados.Infra.Data.Repositories
{
    public class ColaboradorRepository : UsuarioRepository, IColaboradorRepository
    {
        public async Task<IList<Colaborador>> ObterAtivosAsync()
        {
            return await context.Colaboradores.Where(c => c.EstaAtivo).ToListAsync();
        }
    }

}
