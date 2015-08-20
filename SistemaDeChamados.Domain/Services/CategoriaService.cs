using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Repositories;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Domain.Services
{
    public class CategoriaService : ServiceBase<Categoria>, ICategoriaService
    {
        private readonly ICategoriaRepository repository;

        public CategoriaService(ICategoriaRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Categoria> ObterPorSetor(long setorId)
        {
            return repository.ObterPorSetor(setorId);
        }

        public async Task<IEnumerable<Categoria>> ObterPorSetorAsync(long setorId)
        {
            return await repository.ObterPorSetorAsync(setorId);
        }
    }
}
