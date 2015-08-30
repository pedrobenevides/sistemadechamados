 using Microsoft.Practices.ServiceLocation;
 using IServiceLocator = SistemaDeChamados.Application.Interface.Services.IServiceLocator;

namespace SistemaDeChamados.Application.Services
{
    public class CustomServiceLocator : IServiceLocator
    {
        public T GetInstance<T>()
        {
            return ServiceLocator.Current.GetInstance<T>();
        }
    }
}
