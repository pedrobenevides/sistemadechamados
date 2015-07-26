using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Domain.Interfaces.Repositories
{
    public interface ISetorRepository : IRepositoryBase<Setor>
    {
        Setor ObterPorUsuarioId(long usuarioId);
    }
}
