using Ninject.Modules;
using SistemaDeChamados.Domain.Interfaces.Repositories;
using SistemaDeChamados.Infra.Data.Repositories;

namespace SistemaDeChamados.Infra.CrossCuting.IoC
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IChamadoRepository>().To<ChamadoRepository>();
            Bind<IMensagemRepository>().To<MensagemRepository>();
            Bind<IUsuarioRepository>().To<UsuarioRepository>();
        }
    }
}