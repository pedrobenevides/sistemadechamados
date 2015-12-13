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
        protected IDbSet<Chamado> Chamados { get { return context.Chamados; } }

        public async Task<IEnumerable<Mensagem>> Obter5UltimasAsync(long chamadoId)
        {
            return await Mensagens.OrderByDescending(m => m.DataDeCriacao).Take(5).ToListAsync();
        }

        public IEnumerable<Mensagem> Obter5Ultimas(long chamadoId)
        {
            return Mensagens.OrderByDescending(m => m.DataDeCriacao).Take(5);
        }

        public int ObterNumeroDeMensagensNaoLidas(long usuarioId)
        {
            var chamadosIds = Chamados.Where(c => c.ColaboradorId == usuarioId && !c.DataDeEncerramento.HasValue).Select(c => c.Id);
            return Mensagens.Count(m => chamadosIds.Contains(m.ChamadoId) && m.UsuarioId != usuarioId && !m.DataDaLeitura.HasValue);
        }
    }
}
