using System;
using Microsoft.Practices.ServiceLocation;
using SistemaDeChamados.Infra.Data.Contexto;
using SistemaDeChamados.Infra.Data.Interfaces;

namespace SistemaDeChamados.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SistemaContext sistemaContext;
        private readonly IContextManager contextManager = ServiceLocator.Current.GetInstance<IContextManager>();
        private bool isDisposed;

        public UnitOfWork()
        {
            sistemaContext = contextManager.GetContext();
        }

        public void BeginTransaction()
        {
            isDisposed = false;
        }

        public void SaveChanges()
        {
            sistemaContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    sistemaContext.Dispose();
                }
            }

            isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
