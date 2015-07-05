using System;
using System.Data.Entity;
using System.Linq;
using SistemaDeChamados.Domain.Interfaces;
using SistemaDeChamados.Infra.Data.Contexto;

namespace SistemaDeChamados.Infra.Data.Repositories
{
    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
    {
        protected SistemaContext context = new SistemaContext();
        private readonly DbSet<T> dbSet;

        public RepositoryBase()
        {
            dbSet = context.Set<T>();
        }

        public void Create(T entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public IQueryable<T> Retrieve()
        {
            return dbSet;
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
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
