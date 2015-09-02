 using SistemaDeChamados.Domain.Entities;
 using SistemaDeChamados.Domain.Interfaces.Repositories;
 using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Domain.Services
{
    public class AnalistaService : ServiceBase<Analista>, IAnalistaService
    {
        public AnalistaService(IAnalistaRepository repository)
            : base(repository)
        { }
    }
}
