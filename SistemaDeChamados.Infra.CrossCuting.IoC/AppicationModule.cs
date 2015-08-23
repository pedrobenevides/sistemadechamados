using Ninject.Modules;
using SistemaDeChamados.Application.AppServices;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.Interface.Socket;
using SistemaDeChamados.Application.SignalR;

namespace SistemaDeChamados.Infra.CrossCuting.IoC
{
    public class AppicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IChamadoAppService>().To<ChamadoAppService>();
            Bind<IMensagemAppService>().To<MensagemAppService>();
            Bind<IUsuarioAppService>().To<UsuarioAppService>();
            Bind<IColaboradorAppService>().To<ColaboradorAppService>();
            Bind<ISetorAppService>().To<SetorAppService>();
            Bind<IPerfilAppService>().To<PerfilAppService>();
            Bind<ISistemaHub>().To<SistemaHub>();
            Bind<ICategoriaAppService>().To<CategoriaAppService>();
        }
    }
}