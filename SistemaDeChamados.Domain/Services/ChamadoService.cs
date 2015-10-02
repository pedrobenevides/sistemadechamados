using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Enums;
using SistemaDeChamados.Domain.Exceptions;
using SistemaDeChamados.Domain.Extensions;
using SistemaDeChamados.Domain.Interfaces.Repositories;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Domain.Services
{
    public class ChamadoService : ServiceBase<Chamado>,  IChamadoService
    {
        private readonly IChamadoRepository chamadoRepository;
        private readonly IArquivoService arquivoService;

        public ChamadoService(IChamadoRepository chamadoRepository, IArquivoService arquivoService) 
            : base(chamadoRepository)
        {
            this.chamadoRepository = chamadoRepository;
            this.arquivoService = arquivoService;
        }


        public async Task<List<Chamado>> Obter5RecentesPorUsuarioAsync(long usuarioId)
        {
            return await chamadoRepository.Obter5RecentesPorUsuarioAsync(usuarioId);
        }

        public async Task<List<Chamado>> Obter5EmAbertoAsync(long usuarioId)
        {
            return await chamadoRepository.Obter5EmAbertoAsync(usuarioId);
        }

        public void AlterarStatus(long chamadoId, long usuarioId, StatusDoChamado statusNovo)
        {
            var chamado = GetById(chamadoId);

            if(chamado.ColaboradorId != usuarioId && chamado.Categoria.AnalistaId != usuarioId)
                throw new ChamadosException("Usuário não tem permissão de alterar esse chamado.");

            chamadoRepository.AlterarStatus(chamado, statusNovo);
        }

        public async Task CreateComAnexosAsync(Chamado chamado)
        {
            var chamadoSalvo = await chamadoRepository.CreateAndCommitAsync(chamado);
            
            if (chamado.Arquivos.Any())
                await arquivoService.SalvarArquivosFisicos(chamado.Arquivos, chamadoSalvo.Id);
        }

        public async Task AlterarStatusAsync(long id, long usuarioId, string status)
        {
            var chamado = await chamadoRepository.GetByIdAsync(id);

            await Task.Run(() =>
            {
                if (chamado.ColaboradorId != usuarioId && chamado.Categoria.AnalistaId != usuarioId)
                    throw new ChamadosException("Usuário não tem permissão de alterar esse chamado.");

                chamado.AlterarStatus(status.ToEnum<StatusDoChamado>());
            });
        }
    }
}
