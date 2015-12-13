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
        //TODO: Devolver o retorno paginado
        public IQueryable<T> Obter()
        {
            return dbSet;
        }
        //TODO: Devolver o retorno paginado
        public IQueryable<T> ObterAsNoTracking()
        {
            return dbSet.AsNoTracking();
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
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

        public async Task<T> GetByIdAsync(long id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
