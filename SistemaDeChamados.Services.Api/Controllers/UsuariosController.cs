using System.Web.Http;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Domain.Exceptions;

namespace SistemaDeChamados.Services.Api.Controllers
{
    public class UsuariosController : ApiController
    {
        private readonly IUsuarioAppService usuarioAppService;

        public UsuariosController(IUsuarioAppService usuarioAppService)
        {
            this.usuarioAppService = usuarioAppService;
        }

        [HttpGet]
        public IHttpActionResult AlterarStatus(long id)
        {
            try
            {
                usuarioAppService.AlterarStatus(id);
                return Ok();
            }
            catch (ChamadosException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
