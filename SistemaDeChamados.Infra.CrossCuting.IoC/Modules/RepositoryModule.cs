using Ninject.Extensions.Conventions;
using Ninject.Modules;
using SistemaDeChamados.Infra.Data.Repositories;

namespace SistemaDeChamados.Infra.CrossCuting.IoC.Modules
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(convencao => convencao.FromAssemblyContaining(typeof (RepositoryBase<>)).SelectAllClasses().BindDefaultInterface().Configure(c => c.InTransientScope()));
        }
    }
}