using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Web.Controllers;

namespace SistemaDeChamados.Web.Tests.Controllers
{
    [TestClass]
    public class DadoUmChamadosController
    {
        private ChamadosController chamadosController;
        private ISetorAppService setorAppService;
        private ICategoriaAppService categoriaAppService;
        private IChamadoAppService chamadoAppService;

        [TestInitialize]
        public void Cenario()
        {
            setorAppService = Substitute.For<ISetorAppService>();
            categoriaAppService = Substitute.For<ICategoriaAppService>();
            chamadoAppService = Substitute.For<IChamadoAppService>();

            chamadosController = new ChamadosController(setorAppService);
        }

        [TestMethod]
        public void AoCriarUmChamadoDeveChamarOMetodoCreateDoAppService()
        {
            var vm = new CriacaoChamadoVM();
            chamadosController.Novo(vm);
        }
    }
}
