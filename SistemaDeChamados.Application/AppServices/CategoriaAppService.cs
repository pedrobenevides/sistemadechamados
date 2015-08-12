using System.Collections.Generic;
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
    }
}
