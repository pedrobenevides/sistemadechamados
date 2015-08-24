using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
//using System.Web .Http.Controllers;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SistemaDeChamados.Application.Identity;
using SistemaDeChamados.Web.Filters;

namespace SistemaDeChamados.Web.Tests.Filters
{
    [TestClass]
    public class DadoUmPermissaoAcessoFilter
    {
        private PermissaoAcesso permissaoAcessoFilter;
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

            var actionDescriptor = Substitute.For<ActionDescriptor>();
            context.ActionDescriptor = actionDescriptor;
            context.ActionDescriptor.GetCustomAttributes(typeof (PermissaoLivre), false).Returns(new object[1]{ new PermissaoLivre()});
            permissaoAcessoFilter = new PermissaoAcesso();
        }

        [TestMethod]
        public void AoTentarAcessarRecursoQueTenhaPermissaoLivreOResultDeveSerNulo()
        {
            context.RouteData.Values.Add("controller", "Account");
            context.RouteData.Values.Add("action", "Login");

            permissaoAcessoFilter.OnActionExecuting(context);
            var resultado = (RedirectToRouteResult)context.Result;

            Assert.AreEqual(resultado, null);
        }

        [TestMethod]
        public void AoTentarAcessarRecursoQueNaoTemPermissaoDeveRedirecionarParaNaoPermitido()
        {
            context.ActionDescriptor.GetCustomAttributes(typeof(PermissaoLivre), false).Returns(new object[0]);

            context.RouteData.Values.Add("controller","Usuario");
            context.RouteData.Values.Add("action","Index");

            var claim = new ClaimsIdentity(new List<Claim> { new Claim(CustomClaimTypes.Acoes, "Chamados|Index;") });
            requestContext.HttpContext.User.Identity.Returns(claim);

            permissaoAcessoFilter.OnActionExecuting(context);
            var resultado = (RedirectToRouteResult)context.Result;

            Assert.AreEqual(resultado.RouteValues.Values.ElementAt(1), "NaoPermitido");
        }

        [TestMethod]
        public void AoTentarAcessarRecursoQueTenhaPermissaoOResultDeveSerNulo()
        {
            context.RouteData.Values.Add("controller", "Usuario");
            context.RouteData.Values.Add("action", "Index");

            var claim = new ClaimsIdentity(new List<Claim> { new Claim(CustomClaimTypes.Acoes, "*;") });
            requestContext.HttpContext.User.Identity.Returns(claim);

            permissaoAcessoFilter.OnActionExecuting(context);
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
            //identity.Setup(id => id.Name).Returns("test");
            //request.Setup(req => req.Url).Returns(new Uri("http://www.google.com"));
            //request.Setup(req => req.RequestContext).Returns(requestContext.Object);
            //requestContext.Setup(x => x.RouteData).Returns(new RouteData());
            //request.SetupGet(req => req.Headers).Returns(new NameValueCollection());

            return httpContext;
        }

    }
}
