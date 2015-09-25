using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Enums;
using SistemaDeChamados.Domain.Exceptions;
using SistemaDeChamados.Domain.Interfaces.Repositories;

namespace SistemaDeChamados.Infra.Data.Repositories
{
    public class ChamadoRepository : RepositoryBase<Chamado>, IChamadoRepository
    {
        protected IDbSet<Chamado> Chamados { get { return context.Chamados; } }

        public async Task<List<Chamado>> Obter5RecentesPorUsuarioAsync(long usuarioId)
        {
            return await
                Chamados.Where(c => c.UsuarioCriador.Id == usuarioId)
                        .Where(c => c.Mensagens.Any(m => !m.DataDaLeitura.HasValue && m.UsuarioId != usuarioId) || c.FoiAtualizado)
                    .OrderByDescending(c => c.DataDeCriacao)
                    .Take(5)
                    .ToListAsync();
        }

        public async Task<List<Chamado>> Obter5EmAbertoAsync(long usuarioId)
        {
            return await
                Chamados.Where(c => c.StatusDoChamado == StatusDoChamado.Aberto && c.ColaboradorId == usuarioId)
                    .OrderBy(c => c.DataDeCriacao)
                    .Take(5)
                    .ToListAsync();
        }

        public void AlterarStatus(Chamado chamado, StatusDoChamado statusNovo)
        {
            chamado.AlterarStatus(statusNovo);
            Update(chamado);
        }

        public async Task<Chamado> CreateAndCommit(Chamado chamado)
        {
            var chamadoDoBanco = Chamados.Add(chamado);
            await context.SaveChangesAsync();

            return chamadoDoBanco;
        }
    }
}
