using Ninject.Modules;
using SistemaDeChamados.Domain.Interfaces.Services;
using SistemaDeChamados.Domain.Services;

namespace SistemaDeChamados.Infra.CrossCuting.IoC
{
    public class DomainModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IChamadoService>().To<ChamadoService>();
            Bind<IMensagemService>().To<MensagemService>();
            Bind<IUsuarioService>().To<UsuarioService>();
            Bind<IColaboradorService>().To<ColaboradorService>();
            Bind<ISetorService>().To<SetorService>();
            Bind<IPerfilService>().To<PerfilService>();
            Bind<ICriptografadorDeSenha>().To<CriptografadorDeSenhaMD5>();
            Bind<ICategoriaService>().To<CategoriaService>();
        }
    }
}