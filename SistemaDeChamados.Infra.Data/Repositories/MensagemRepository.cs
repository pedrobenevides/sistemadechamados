using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Repositories;

namespace SistemaDeChamados.Infra.Data.Repositories
{
    public class MensagemRepository : RepositoryBase<Mensagem>, IMensagemRepository
    {
        protected IDbSet<Mensagem> Mensagens { get { return context.Mensagens; } }

        public async Task<IEnumerable<Mensagem>> Obter5UltimasAsync(long chamadoId)
        {
            return await Mensagens.OrderByDescending(m => m.DataDeCriacao).Take(5).ToListAsync();
        }
    }
}
