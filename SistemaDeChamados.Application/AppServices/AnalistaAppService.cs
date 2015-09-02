using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.Interface.Services;

namespace SistemaDeChamados.Application.AppServices
{
    public class AnalistaAppService : AppService, IAnalistaAppService
    {
        public AnalistaAppService(IServiceLocator serviceLocator) 
            : base(serviceLocator)
        { }
    }
}
