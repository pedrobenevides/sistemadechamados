using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json.Linq;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.Interface.Services;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.Entities;
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

        public async Task<IEnumerable<AnalistaVM>> ObterAsync()
        {
            return await Task.Run(() =>
            {
                var analistasVm = Mapper.Map<Task<IEnumerable<AnalistaVM>>>(analistaService.ObterAsync());
                return analistasVm;
            });
        }
    }
}
