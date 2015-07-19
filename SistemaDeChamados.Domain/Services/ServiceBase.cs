using System.Linq;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.Interfaces.Repositories;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class 
    {
        private readonly IRepositoryBase<T> repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            this.repository = repository;
        }

        public virtual T Create(T entity)
        {
            return repository.Create(entity);
        }

        public virtual IQueryable<T> Retrieve()
        {
            return repository.Retrieve();
        }

        public virtual void Update(T entity)
        {
            repository.Update(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await repository.UpdateAsync(entity);
        }

        public virtual void Delete(long id)
        {
            repository.Delete(id);
        }

        public virtual T GetById(long id)
        {
            return repository.GetById(id);
        }
    }
}
