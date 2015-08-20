using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Services.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
    }
}