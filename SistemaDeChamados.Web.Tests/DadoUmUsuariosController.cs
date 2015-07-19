using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Infra.CrossCuting.Identity.Configuration.IdentityManagers;
using SistemaDeChamados.Infra.CrossCuting.Identity.Entities;
using SistemaDeChamados.Web.Controllers;

namespace SistemaDeChamados.Web.Tests
{
    [TestClass]
    public class DadoUmUsuariosController
    {
        private UsuariosController usuariosController;
        private IUsuarioAppService usuarioAppService;
        private IUserStore<UsuarioIdentity> userStore; 
        private UsuarioIdentity usuarioIdentity;
        private ApplicationUserManager userManager;
        
        [TestInitialize]
        public void Setup()
        {
            HttpContext.Current = CreateHttpContext(false);
            

            usuarioAppService = Substitute.For<IUsuarioAppService>();
            usuariosController = new UsuariosController(usuarioAppService);
            usuarioIdentity = new UsuarioIdentity {UserName = "teste@mail.com", Email = "teste@mail.com"};
            userStore = Substitute.For<IUserStore<UsuarioIdentity>>();
            userManager = Substitute.For<ApplicationUserManager>(userStore);

            var request = Substitute.For<HttpRequestBase>();
            var context = Substitute.For<HttpContextBase>();
            context.Request.Returns(request);
            var controllerContext = new ControllerContext(context, new RouteData(), Substitute.For<ControllerBase>());
            usuariosController.ControllerContext = controllerContext;
            
            var identityBaseController = Substitute.For<IdentityBaseController>();
            identityBaseController.UserManager.Returns(userManager);
            identityBaseController.UserManager.FindByEmailAsync("teste@mail.com");

        }

        private static HttpContext CreateHttpContext(bool userLoggedIn)
        {
            var httpContext = new HttpContext(
                new HttpRequest(string.Empty, "http://sample.com", string.Empty),
                new HttpResponse(new StringWriter())
            )
            {
                User = userLoggedIn
                    ? new GenericPrincipal(new GenericIdentity("userName"), new string[0])
                    : new GenericPrincipal(new GenericIdentity(string.Empty), new string[0])
            };

            return httpContext;
        }
        
        [TestMethod]
        public void IndexDeveListarTodosOsUsuariosEPassarParaAView()
        {
            usuariosController.Index();
            usuarioAppService.Received().ObterReadOnly();
        }

        [TestMethod]
        public void NovoComChamadaGetDevePassarUmUsuarioViewModelParaAView()
        {
            var result = (ViewResult)usuariosController.Novo();
            Assert.AreEqual(typeof(UsuarioVM), result.Model.GetType());
        }

        [TestMethod]
        public void AoRealizarUmPostParaAActionNovoDeveChamarOMetodoCreateDoUsuarioAppServiceSeModelIsValid()
        {
            var vm = new UsuarioVM
            {
                Nome = "Fulano",
                Email = "fulano@mail.com",
                Password = "123456",
                ConfirmacaoPassword = "123456"
            };

            usuariosController.Novo(vm);
            usuarioAppService.Received().Create(vm);
        }

        [TestMethod]
        public void AoRealizarUmPostParaAActionNovoDeveRetornarAViewSeModelIsNotValid()
        {
            //var badModel = ObterViewModelInvalido();
            //var result = (ViewResult)usuariosController.Novo(badModel);
            //Assert.AreEqual(typeof(UsuarioVM), result.Model.GetType());
        }


        [TestMethod]
        public void EdicaoComChamadaGetDevePopularOViewModelEId()
        {
            const int idProcurado = 1;
            usuarioAppService.ObterParaEdicao(idProcurado).Returns(new UsuarioVM());
            var result = (ViewResult)usuariosController.Edicao(idProcurado);

            Assert.AreEqual(idProcurado, ((UsuarioVM)result.Model).Id);
        }

        [TestMethod]
        public async Task AoRealizarUmPostParaAActionEdicaoDeveRetornarAViewSeModelIsNotValid()
        {
            var badModel = ObterViewModelInvalido();
            var result = await usuariosController.Edicao(badModel) as ViewResult;
            
            Assert.AreEqual(typeof(UsuarioVM), result.Model.GetType());
        }

        [TestMethod]
        public async Task AoRealizarUmPostParaAActionEdicaoDeveChamarOMetodoCreateDoUsuarioAppServiceSeModelIsValid()
        {
            var vm = new UsuarioVM
            {
                Nome = "Fulano",
                Email = "fulano@mail.com"
            };

            userManager.FindByEmailAsync(vm.Email).Returns(new Task<UsuarioIdentity>(() => new UsuarioIdentity()));
            await usuariosController.Edicao(vm);
            await usuarioAppService.Received().UpdateAsync(vm);
        }

        private UsuarioVM ObterViewModelInvalido()
        {
            var badModel = new UsuarioVM();
            var validationContext = new ValidationContext(badModel, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(badModel, validationContext, validationResults, true);
            foreach (var validationResult in validationResults)
            {
                usuariosController.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }

            return badModel;
        }

    }
}
