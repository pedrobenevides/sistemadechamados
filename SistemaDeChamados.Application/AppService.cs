using System.Threading.Tasks;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.Interface.Services;
using SistemaDeChamados.Infra.Data.Interfaces;

namespace SistemaDeChamados.Application
{
    public class AppService : IAppService
    {
        private readonly IServiceLocator serviceLocator;
        private IUnitOfWork uow;

        public AppService(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public void BeginTransaction()
        {
            uow = serviceLocator.GetInstance<IUnitOfWork>();
            uow.BeginTransaction();
        }

        public void Commit()
        {
            uow.SaveChanges();
        }

        public Task CommitAsync()
        {
            return uow.SaveChangesAsync();
        }
    }
}
