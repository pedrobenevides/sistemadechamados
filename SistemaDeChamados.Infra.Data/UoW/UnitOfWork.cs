using System;
using System.Data.Entity.Validation;
using System.Text;
using System.Threading.Tasks;
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
            try
            {
                sistemaContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb.ToString(), ex); 
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await sistemaContext.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb.ToString(), ex);
            }
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
