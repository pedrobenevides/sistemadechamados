using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;

namespace SistemaDeChamados.Services.Api.Controllers
{
    public class MensagensController : ApiController
    {
        private readonly IMensagemAppService mensagemAppService;

        public MensagensController(IMensagemAppService mensagemAppService)
        {
            this.mensagemAppService = mensagemAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<MensagemVM>> ObterMensagens(long chamadoId)
        {
            return await mensagemAppService.Obter5UltimasAsync(chamadoId);
        }

        [HttpGet]
        public IEnumerable<MensagemVM> ObterCinco(long chamadoId)
        {
            return mensagemAppService.Obter5Ultimas(chamadoId);
        }
    }
}
