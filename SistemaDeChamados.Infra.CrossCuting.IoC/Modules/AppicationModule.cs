using Ninject.Extensions.Conventions;
using Ninject.Modules;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.Interface.Services;
using SistemaDeChamados.Application.Services;

namespace SistemaDeChamados.Infra.CrossCuting.IoC.Modules
{
    public class AppicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IServiceLocator>().To<CustomServiceLocator>();
            Kernel.Bind(x => x.FromAssemblyContaining(typeof (IAppService)).SelectAllClasses().BindDefaultInterface().Configure(c => c.InTransientScope()));
        }
    }
}