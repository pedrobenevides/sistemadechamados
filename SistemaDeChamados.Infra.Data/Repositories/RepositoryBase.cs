using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

        public T Create(T entity)
        {
            var obj = dbSet.Add(entity);
            return obj;
        }

        public IQueryable<T> Retrieve()
        {
            return dbSet;
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public void Delete(long id)
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
