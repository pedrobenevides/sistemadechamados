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
    }
}
