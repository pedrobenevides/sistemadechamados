using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SistemaDeChamados.Domain.Exceptions;
using SistemaDeChamados.Domain.Services;
using SistemaDeChamados.Web.Controllers;

namespace SistemaDeChamados.Web.Tests.Controllers
{
    [TestClass]
    public class DadoUmBaseController
    {
        private BaseController baseController;
        private HttpContextBase httpContextBase;

        [TestInitialize]
        public void Cenario()
        {
            baseController = new BaseController();
            httpContextBase = Substitute.For<HttpContextBase>();
            httpContextBase.User.Identity.Returns(new ClaimsIdentity(new List<Claim>{new Claim("Acoes","*|*;")}));

            var controllerContext = new ControllerContext { HttpContext = httpContextBase };
            baseController.ControllerContext = controllerContext;

            HttpContextFactory.SetCurrentContext(GetMockedHttpContext());
        }

        [TestMethod, ExpectedException(typeof(ChamadosException))]
        public void NaMontagemDoMenuSeNaoConseguirObterAsClaimsDeveLancarExecption()
        {
            httpContextBase.User.Identity.Returns((IIdentity)null);
            baseController.Menu();
        }

        [TestMethod]
        public void MenuDeveListarTodosOsItensSeUsuarioLogadoTiverTodasAsPermissoes()
        {
            var todasPermissoes = PerfilService.TodosAcessosDoSistema().Where(x => x.Controller != "*");
            var resultado = baseController.Menu() as PartialViewResult;
            
            Assert.AreEqual(((Dictionary<string, string>)resultado.Model).Count, todasPermissoes.Count());
        }

        [TestMethod]
        public void MenuDeveListarApenasOsItensQueOUsuarioLogadoTemAcesso()
        {
            httpContextBase.User.Identity.Returns(new ClaimsIdentity(new List<Claim> { new Claim("Acoes", "Usuarios|*;Perfil|*;") }));
            var resultado = baseController.Menu() as PartialViewResult;

            Assert.AreEqual(((Dictionary<string, string>)resultado.Model).Count, 2);
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

            context.User.Identity.Returns(new ClaimsIdentity(new List<Claim>()));
            
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
