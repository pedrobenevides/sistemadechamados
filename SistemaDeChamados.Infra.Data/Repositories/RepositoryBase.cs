using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using SistemaDeChamados.Domain.Interfaces.Repositories;
using SistemaDeChamados.Infra.Data.Contexto;
using SistemaDeChamados.Infra.Data.Interfaces;

namespace SistemaDeChamados.Infra.Data.Repositories
{
    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
    {
        protected SistemaContext context;
        private IContextManager contextManager;
        private readonly DbSet<T> dbSet;
        
        public RepositoryBase()
        {
            contextManager = ServiceLocator.Current.GetInstance<IContextManager>();
            context = contextManager.GetContext();
            dbSet = context.Set<T>();
        }

        public virtual T Create(T entity)
        {
            var obj = dbSet.Add(entity);
            return obj;
        }

        public virtual IQueryable<T> Retrieve()
        {
            return dbSet;
        }

        public virtual void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(long id)
        {
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);

            context.SaveChanges();
        }

        public T GetById(long id)
        {
            return dbSet.Find(id);
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
