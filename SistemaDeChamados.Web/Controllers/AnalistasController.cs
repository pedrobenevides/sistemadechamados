 using System.Threading.Tasks;
 using System.Web.Mvc;
 using SistemaDeChamados.Application.Interface;

namespace SistemaDeChamados.Web.Controllers
{
    public class AnalistasController : Controller
    {
        private readonly IAnalistaAppService analistaAppService;

        public AnalistasController(IAnalistaAppService analistaAppService)
        {
            this.analistaAppService = analistaAppService;
        }

        [HttpGet]
        public async Task<ActionResult> IndexAsync()
        {
            return View(await analistaAppService.ObterAsync());
        }
    }
}