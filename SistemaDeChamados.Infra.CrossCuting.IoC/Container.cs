using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using SistemaDeChamados.Infra.CrossCuting.IoC.Modules;

namespace SistemaDeChamados.Infra.CrossCuting.IoC
{
    public class Container
    {
        public Container()
        {
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(GetModules()));
        }

        public StandardKernel GetModules()
        {
            return new StandardKernel(new DomainModule(), new RepositoryModule(), new AppicationModule());
        }
    }
}
