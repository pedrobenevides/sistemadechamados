using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Repositories;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Domain.Services
{
    public class MensagemService : ServiceBase<Mensagem>, IMensagemService
    {
        private readonly IMensagemRepository mensagemRepository;

        public MensagemService(IMensagemRepository mensagemRepository)
            :base(mensagemRepository)
        {
            this.mensagemRepository = mensagemRepository;
        }

        public async Task<IEnumerable<Mensagem>> Obter5UltimasAsync(long chamadoId)
        {
            return await mensagemRepository.Obter5UltimasAsync(chamadoId);
        }

        public IEnumerable<Mensagem> Obter5Ultimas(long chamadoId)
        {
            return mensagemRepository.Obter5Ultimas(chamadoId);
        }

        public int ObterNumeroDeMensagensNaoLidas(long usuarioId)
        {
            return mensagemRepository.ObterNumeroDeMensagensNaoLidas(usuarioId);
        }
    }
}
