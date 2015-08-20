using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Application.AppServices
{
    public class CategoriaAppService : AppService, ICategoriaAppService
    {
        private readonly ICategoriaService categoriaService;

        public CategoriaAppService(ICategoriaService categoriaService)
        {
            this.categoriaService = categoriaService;
        }

        public IEnumerable<Categoria> ObterTodasCategorias()
        {
            return categoriaService.Retrieve();
        }

        public IEnumerable<Categoria> ObterPorSetor(long setorId)
        {
            return categoriaService.ObterPorSetor(setorId);
        }

        public async Task<IEnumerable<Categoria>> ObterPorSetorAsync(long setorId)
        {
            return await categoriaService.ObterPorSetorAsync(setorId);
        }
    }
}
