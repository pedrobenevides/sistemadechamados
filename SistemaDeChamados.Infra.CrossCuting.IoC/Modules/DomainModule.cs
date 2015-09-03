using Ninject.Extensions.Conventions;
using Ninject.Modules;
using SistemaDeChamados.Domain.Interfaces.Services;
using SistemaDeChamados.Domain.Services;

namespace SistemaDeChamados.Infra.CrossCuting.IoC.Modules
{
    public class DomainModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(config => config.FromAssemblyContaining(typeof(IServiceBase<>)).SelectAllClasses().BindDefaultInterface().Configure(c => c.InTransientScope()));
            Bind<ICriptografadorDeSenha>().To<CriptografadorDeSenhaMD5>();
        }
    }
}