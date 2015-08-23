using Ninject.Modules;
using SistemaDeChamados.Domain.Interfaces.Repositories;
using SistemaDeChamados.Infra.Data.Contexto;
using SistemaDeChamados.Infra.Data.Interfaces;
using SistemaDeChamados.Infra.Data.Repositories;
using SistemaDeChamados.Infra.Data.UoW;

namespace SistemaDeChamados.Infra.CrossCuting.IoC
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IChamadoRepository>().To<ChamadoRepository>();
            Bind<IMensagemRepository>().To<MensagemRepository>();
            Bind<IUsuarioRepository>().To<UsuarioRepository>();
            Bind<IColaboradorRepository>().To<ColaboradorRepository>();
            Bind<ISetorRepository>().To<SetorRepository>();
            Bind<IPerfilRepository>().To<PerfilRepository>();
            Bind<ICategoriaRepository>().To<CategoriaRepository>();
            Bind(typeof (IRepositoryBase<>)).To(typeof (RepositoryBase<>));
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IContextManager>().To<ContextManager>();
        }
    }
}