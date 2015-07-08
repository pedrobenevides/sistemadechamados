using Ninject.Modules;
using SistemaDeChamados.Application.AppServices;
using SistemaDeChamados.Application.Interface;

namespace SistemaDeChamados.Infra.CrossCuting.IoC
{
    public class AppicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IChamadoAppService>().To<ChamadoAppService>();
            Bind<IMensagemAppService>().To<MensagemAppService>();
            Bind<IUsuarioAppService>().To<UsuarioAppService>();
        }
    }
}