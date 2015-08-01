using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SistemaDeChamados.Application.Identity;
using SistemaDeChamados.Web.Filters;

namespace SistemaDeChamados.Web.Tests.Filters
{
    [TestClass]
    public class DadoUmPermissaoLivreAttribute
    {
        private PermissaoLivre permissaoLivre;
        private ActionExecutingContext context;
        private RequestContext requestContext;
        private HttpRequestBase request;

        [TestInitialize]
        public void Cenario()
        {
            requestContext = Substitute.For<RequestContext>();
            request = Substitute.For<HttpRequestBase>();

            context = new ActionExecutingContext
            {
                HttpContext = GetMockedHttpContext(),
                RouteData = new RouteData()
            };
            permissaoLivre = new PermissaoLivre();
        }

        [TestMethodAttribute]
        public void AoTentarAcessarRecursoENaoExistaUsuarioLogadoNaAplicacaoDeveRetornarParaOLogin()
        {
            context.RouteData.Values.Add("controller", "Usuario");
            context.RouteData.Values.Add("action", "Index");

            var claim = new ClaimsIdentity(new List<Claim> { new Claim(CustomClaimTypes.Acoes, "*;") });
            requestContext.HttpContext.User.Identity.Returns(claim);

            requestContext.HttpContext.User.Returns((IPrincipal)null);

            permissaoLivre.OnActionExecuting(context);
            var resultado = (RedirectToRouteResult)context.Result;

            Assert.AreEqual(resultado.RouteValues.Values.ElementAt(1), "Login");
        }

        [TestMethodAttribute]
        public void AoTentarAcessarRecursoComUsuarioLogadoOResultDeveSerNulo()
        {
            context.RouteData.Values.Add("controller", "Usuario");
            context.RouteData.Values.Add("action", "Index");

            var claim = new ClaimsIdentity(new List<Claim> { new Claim(CustomClaimTypes.Acoes, "*;") });
            requestContext.HttpContext.User.Identity.Returns(claim);

            permissaoLivre.OnActionExecuting(context);
            var resultado = (RedirectToRouteResult)context.Result;

            Assert.AreEqual(resultado, null);
        }

        private HttpContextBase GetMockedHttpContext()
        {
            var httpContext = Substitute.For<HttpContextBase>();
            var response = Substitute.For<HttpResponseBase>();
            var session = Substitute.For<HttpSessionStateBase>();
            var server = Substitute.For<HttpServerUtilityBase>();
            var user = Substitute.For<IPrincipal>();
            var identity = Substitute.For<IIdentity>();
            var urlHelper = Substitute.For<UrlHelper>();

            var routes = new RouteCollection();
            //MvcApplication.RegisterRoutes(routes);
            requestContext.HttpContext.Returns(httpContext);
            requestContext.HttpContext.Request.Returns(request);
            requestContext.HttpContext.Response.Returns(response);
            requestContext.HttpContext.Session.Returns(session);
            requestContext.HttpContext.Server.Returns(server);
            requestContext.HttpContext.User.Returns(user);
            requestContext.HttpContext.User.Identity.Returns(identity);
            requestContext.HttpContext.User.Identity.IsAuthenticated.Returns(false);
            requestContext.HttpContext.Request.RequestContext.Returns(requestContext);
            identity.Name.Returns("Admin");

            return httpContext;
        }
    }
}
