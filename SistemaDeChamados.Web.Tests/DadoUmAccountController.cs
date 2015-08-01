using System;
using System.Collections.Specialized;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Web.Controllers;

namespace SistemaDeChamados.Web.Tests
{
    [TestClass]
    public class DadoUmAccountController
    {
        private AccountController accountController;
        private IUsuarioAppService usuarioAppService;
        private LoginVM loginVM;

        [TestInitialize]
        public void Setup()
        {
            usuarioAppService = Substitute.For<IUsuarioAppService>();
            accountController = new AccountController(usuarioAppService);

            loginVM = new LoginVM
            {
                Login = "teste@mail.com",
                Senha = "sdfsdjdjgf86fgdg7d6786875sdfsdfsdf"
            };
        }

        //[TestMethod]
        //public void ConsigoRealizarOLogin()
        //{
        //    HttpContextFactory.SetCurrentContext(GetMockedHttpContext());
            
        //    var httpContextBase = Substitute.For<HttpContextBase>();
        //    var controllerContext = new ControllerContext {HttpContext = httpContextBase};
        //    accountController.ControllerContext = controllerContext;
            
        //    usuarioAppService.ObterUsuarioLogado(loginVM).Returns(new UsuarioLogadoVM{Id = 1, Email = "teste@mail.com", Nome = "Pedro"});
        //    var result = (RedirectResult)accountController.Login(loginVM, null);
        //}

        [TestMethod, Ignore]
        public void AoTentarLogarSeLoginOuSenhaInvalidosRetornaParaAViewComModel()
        {
            usuarioAppService.ObterUsuarioLogado(loginVM);
            var result = (ViewResult)accountController.Login(loginVM, null);

            Assert.AreEqual(typeof(LoginVM), result.Model.GetType());
        }

        private static HttpContextBase GetMockedHttpContext()
        {
            var context = Substitute.For<HttpContextBase>();
            var request = Substitute.For<HttpRequestBase>();
            var response = Substitute.For<HttpResponseBase>();
            var session = Substitute.For<HttpSessionStateBase>();
            var server = Substitute.For<HttpServerUtilityBase>();
            var user = Substitute.For<IPrincipal>();
            var identity = Substitute.For<IIdentity>();
            var urlHelper = Substitute.For<UrlHelper>();

            var routes = new RouteCollection();
            //MvcApplication.RegisterRoutes(routes);
            var requestContext = Substitute.For<RequestContext>();
            requestContext.HttpContext.Returns(context);
            requestContext.HttpContext.Request.Returns(request);
            requestContext.HttpContext.Response.Returns(response);
            requestContext.HttpContext.Session.Returns(session);
            requestContext.HttpContext.Server.Returns(server);
            requestContext.HttpContext.User.Returns(user);
            requestContext.HttpContext.User.Identity.Returns(identity);
            requestContext.HttpContext.User.Identity.IsAuthenticated.Returns(false);
            requestContext.HttpContext.Request.RequestContext.Returns(requestContext);

            //identity.Setup(id => id.Name).Returns("test");
            //request.Setup(req => req.Url).Returns(new Uri("http://www.google.com"));
            //request.Setup(req => req.RequestContext).Returns(requestContext.Object);
            //requestContext.Setup(x => x.RouteData).Returns(new RouteData());
            //request.SetupGet(req => req.Headers).Returns(new NameValueCollection());

            return context;
        }
    }

    public class HttpContextFactory
    {
        private static HttpContextBase m_context;
        public static HttpContextBase Current
        {
            get
            {
                if (m_context != null)
                    return m_context;

                if (HttpContext.Current == null)
                    throw new InvalidOperationException("HttpContext not available");

                return new HttpContextWrapper(HttpContext.Current);
            }
        }

        public static void SetCurrentContext(HttpContextBase context)
        {
            m_context = context;
        }
    }
}
