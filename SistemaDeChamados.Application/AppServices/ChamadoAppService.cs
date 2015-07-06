using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Application.AppServices
{
    public class ChamadoAppService : IChamadoAppService
    {
        private readonly IChamadoService chamadoService;

        public ChamadoAppService(IChamadoService chamadoService)
        {
            this.chamadoService = chamadoService;
        }

        public void Create(ChamadoVM chamadoVM)
        {
            var chamado = Mapper.Map<Chamado>(chamadoVM);
            chamadoService.Create(chamado);
        }

        public IEnumerable<ChamadoVM> Retrieve()
        {
            var listaDeChamados = chamadoService.Retrieve();
            return Mapper.Map<IList<ChamadoVM>>(listaDeChamados.ToList());
        }

        public void Update(ChamadoVM chamadoVM)
        {
            var chamado = Mapper.Map<Chamado>(chamadoVM);
            chamadoService.Update(chamado);
        }

        public void Delete(long id)
        {
            chamadoService.Delete(id);
        }

        public ChamadoVM GetById(long id)
        {
            var chamado = chamadoService.GetById(id);
            return Mapper.Map<ChamadoVM>(chamado);
        }
    }
}
