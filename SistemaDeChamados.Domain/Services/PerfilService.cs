using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Repositories;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Domain.Services
{
    public class PerfilService : ServiceBase<Perfil>, IPerfilService
    {
        private readonly IPerfilRepository perfilRepository;

        public PerfilService(IPerfilRepository perfilRepository) : base(perfilRepository)
        {
            this.perfilRepository = perfilRepository;
        }
    }
}
