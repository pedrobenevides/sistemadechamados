using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Repositories;

namespace SistemaDeChamados.Domain.Services
{
    public class CategoriaService : ServiceBase<Categoria>, ICategoriaRepository
    {
        private readonly ICategoriaRepository repository;

        public CategoriaService(ICategoriaRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
