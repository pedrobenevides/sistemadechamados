using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Repositories;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Domain.Services
{
    public class SetorService : ServiceBase<Setor>, ISetorService
    {
        private readonly ISetorRepository setorRepository;

        public SetorService(ISetorRepository setorRepository) : base(setorRepository)
        {
            this.setorRepository = setorRepository;
        }

        public Setor ObterPorUsuarioId(long usuarioId)
        {
            return setorRepository.ObterPorUsuarioId(usuarioId);
        }
    }
}
