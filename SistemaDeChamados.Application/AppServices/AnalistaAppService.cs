using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.Interface.Services;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Application.AppServices
{
    public class AnalistaAppService : AppService, IAnalistaAppService
    {
        private readonly IAnalistaService analistaService;

        public AnalistaAppService(IServiceLocator serviceLocator, IAnalistaService analistaService) 
            : base(serviceLocator)
        {
            this.analistaService = analistaService;
        }

        public string ObterNomePorId(long id)
        {
            return analistaService.ObterNomePorId(id);
        }
    }
}
