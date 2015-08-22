using System.Collections.Generic;
using System.Web.Http;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Services.Api.Controllers
{
    public class CategoriasController : ApiController   
    {
        private readonly ICategoriaAppService categoriaAppService;

        public CategoriasController(ICategoriaAppService categoriaAppService)
        {
            this.categoriaAppService = categoriaAppService;
        }

        [HttpGet]
        public IEnumerable<Categoria> Listar(long setorId)
        {
            return categoriaAppService.ObterPorSetor(setorId);
        }

        [HttpGet]
        public string Echo()
        {
            return "Vai!";
        }
    }
}