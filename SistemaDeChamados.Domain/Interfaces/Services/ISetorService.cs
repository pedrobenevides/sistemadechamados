using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Domain.Interfaces.Services
{
    public interface ISetorService : IServiceBase<Setor>
    {
        Setor ObterPorUsuarioId(long usuarioId);
    }
}
