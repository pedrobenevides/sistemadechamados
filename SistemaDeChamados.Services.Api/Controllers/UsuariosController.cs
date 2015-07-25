using System;
using System.Web.Http;
using System.Web.Http.Cors;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Domain.Exceptions;

namespace SistemaDeChamados.Services.Api.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
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
