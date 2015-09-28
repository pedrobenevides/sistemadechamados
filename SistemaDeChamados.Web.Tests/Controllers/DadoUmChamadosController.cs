using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.Interface.Socket;
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
        private IMensagemAppService mensagemAppService;
        private ISistemaHub signalRHub;

        [TestInitialize]
        public void Cenario()
        {
            var httpContextBase = Substitute.For<HttpContextBase>();
            httpContextBase.User.Identity.Returns(new ClaimsIdentity(new List<Claim> { new Claim("Id", "1") }));

            setorAppService = Substitute.For<ISetorAppService>();
            categoriaAppService = Substitute.For<ICategoriaAppService>();
            chamadoAppService = Substitute.For<IChamadoAppService>();
            mensagemAppService = Substitute.For<IMensagemAppService>();
            signalRHub = Substitute.For<ISistemaHub>();

            chamadosController = new ChamadosController(setorAppService, chamadoAppService, categoriaAppService, signalRHub, mensagemAppService);

            var controllerContext = new ControllerContext { HttpContext = httpContextBase };
            chamadosController.ControllerContext = controllerContext;
        }

        [TestMethod]
        public void AoCriarUmChamadoDeveChamarOMetodoCreateDoAppService()
        {
            var vm = new CriacaoChamadoVM();
            chamadosController.Novo(vm);

            chamadoAppService.Received().CreateAsync(vm);
        }

        public void AoCriarChamadoComAnexoSalvaOAnexoNoDisco()
        {
            
        }

        private static HttpContextBase GetMockedHttpContext()
        {
            var context = Substitute.For<HttpContextBase>();
            var request = Substitute.For<HttpRequestBase>();
            var response = Substitute.For<HttpResponseBase>();
            var server = Substitute.For<HttpServerUtilityBase>();
            var user = Substitute.For<IPrincipal>();
            var identity = Substitute.For<IIdentity>();
            var requestContext = Substitute.For<RequestContext>();
            requestContext.HttpContext.Returns(context);
            requestContext.HttpContext.Request.Returns(request);
            requestContext.HttpContext.Response.Returns(response);
            requestContext.HttpContext.Server.Returns(server);
            requestContext.HttpContext.User.Returns(user);
            requestContext.HttpContext.User.Identity.Returns(new ClaimsIdentity(new List<Claim>()));
            
            requestContext.HttpContext.Request.RequestContext.Returns(requestContext);
            
            return context;
        }
    }
}
