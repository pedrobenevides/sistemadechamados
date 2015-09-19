using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Enums;
using SistemaDeChamados.Domain.Exceptions;
using SistemaDeChamados.Domain.Interfaces.Repositories;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Domain.Services
{
    public class ChamadoService : ServiceBase<Chamado>,  IChamadoService
    {
        private readonly IChamadoRepository chamadoRepository;

        public ChamadoService(IChamadoRepository chamadoRepository) 
            : base(chamadoRepository)
        {
            this.chamadoRepository = chamadoRepository;
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
    }
}
