using Ninject;

namespace SistemaDeChamados.Infra.CrossCuting.IoC
{
    public class Container
    {
        public StandardKernel GetModules()
        {
            return new StandardKernel(new DomainModule(), new RepositoryModule(), new AppicationModule());
        }
    }
}
