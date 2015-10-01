using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SistemaDeChamados.Application.Interface;

namespace SistemaDeChamados.Services.Api.Controllers
{
    public class ChamadosController : ApiController
    {
        private readonly IChamadoAppService chamadoAppService;

        public ChamadosController(IChamadoAppService chamadoAppService)
        {
            this.chamadoAppService = chamadoAppService;
        }

        [HttpDelete]
        public IHttpActionResult Excluir(long id)
        {
            try
            {
                chamadoAppService.Delete(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}