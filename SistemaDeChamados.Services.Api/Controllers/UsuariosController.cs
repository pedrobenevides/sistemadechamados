using System.Web.Http;
using SistemaDeChamados.Application.Interface;

namespace SistemaDeChamados.Services.Api.Controllers
{
    public class UsuariosController : ApiController
    {
        private readonly IUsuarioAppService usuarioAppService;

        public UsuariosController(IUsuarioAppService usuarioAppService)
        {
            this.usuarioAppService = usuarioAppService;
        }

        [HttpPut]
        public IHttpActionResult AlterarStatus()
        {
            return NotFound();
        }
    }
}
