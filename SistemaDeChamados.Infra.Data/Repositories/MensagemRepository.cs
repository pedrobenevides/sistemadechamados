using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces;
using SistemaDeChamados.Domain.Interfaces.Repositories;

namespace SistemaDeChamados.Infra.Data.Repositories
{
    public class MensagemRepository : RepositoryBase<Mensagem>, IMensagemRepository
    {
    }
}
