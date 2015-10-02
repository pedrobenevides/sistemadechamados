using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels.Api.Chamados;

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

        [HttpPut]
        public async Task<IHttpActionResult> AlterarStatusAsync(AlterarStatusVM novoStatus)
        {
            try
            {
                await chamadoAppService.AlterarStatusAsync(novoStatus.Id, novoStatus.UsuarioId, novoStatus.Status);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}