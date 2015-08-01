using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Domain.Interfaces.Repositories
{
    public interface IPerfilRepository : IRepositoryBase<Perfil>
    {
        Perfil ObterPeloIdDoUsuario(long id);
    }
}
