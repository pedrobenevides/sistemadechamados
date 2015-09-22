 using System.Collections.Generic;
 using System.Threading.Tasks;
 using SistemaDeChamados.Domain.Entities;
 using SistemaDeChamados.Domain.Interfaces.Repositories;
 using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Domain.Services
{
    public class AnalistaService : ServiceBase<Analista>, IAnalistaService
    {
        private readonly IAnalistaRepository repository;

        public AnalistaService(IAnalistaRepository repository)
            : base(repository)
        {
            this.repository = repository;
        }

        public string ObterNomePorId(long id)
        {
            return repository.ObterNomePorId(id);
        }

        public async Task<IEnumerable<Analista>> ObterAsync()
        {
            return await repository.ObterAsync();
        }
    }
}
