using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Repositories;

namespace SistemaDeChamados.Infra.Data.Repositories
{
    public class ChamadoRepository : RepositoryBase<Chamado>, IChamadoRepository
    {
        public IDbSet<Chamado> Chamados { get { return context.Chamados; } }

        public async Task<List<Chamado>> Obter5RecentesPorUsuarioAsync(long usuarioId)
        {
            return await
                Chamados.Where(c => c.UsuarioCriador.Id == usuarioId)
                        .Where(c => c.Mensagens.Any(m => !m.DataDaLeitura.HasValue && m.UsuarioId != usuarioId) || c.FoiAtualizado)
                    .OrderByDescending(c => c.DataDeCriacao)
                    .Take(5)
                    .ToListAsync();
        }
    }
}
