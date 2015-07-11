using Microsoft.Practices.ServiceLocation;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Infra.Data.Interfaces;

namespace SistemaDeChamados.Application
{
    public class AppService : IAppService
    {
        private IUnitOfWork uow;

        public void BeginTransaction()
        {
            uow = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            uow.BeginTransaction();
        }

        public void Commit()
        {
            uow.SaveChanges();
        }
    }
}
