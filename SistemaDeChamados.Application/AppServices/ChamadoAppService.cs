using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.Interface.Services;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.DTO;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Application.AppServices
{
    public class ChamadoAppService : AppService, IChamadoAppService
    {
        private readonly IChamadoService chamadoService;

        public ChamadoAppService(IChamadoService chamadoService, IServiceLocator serviceLocator)
            : base(serviceLocator)
        {
            this.chamadoService = chamadoService;
        }

        public void Create(CriacaoChamadoVM chamadoVM)
        {
            var chamado = Mapper.Map<Chamado>(chamadoVM);
            BeginTransaction();
            chamadoService.Create(chamado);
            Commit();
        }

        public IEnumerable<ChamadoIndexVM> Retrieve()
        {
            var listaDeChamados = chamadoService.Obter();
            return Mapper.Map<IList<ChamadoIndexVM>>(listaDeChamados.ToList());
        }

        public void Update(ChamadoVM chamadoVM)
        {
            var chamado = Mapper.Map<Chamado>(chamadoVM);
            BeginTransaction();
            chamadoService.Update(chamado);
            Commit();
        }

        public void Delete(long id)
        {
            BeginTransaction();
            chamadoService.Delete(id);
            Commit();
        }

        public ChamadoVM GetById(long id)
        {
            var chamado = chamadoService.GetById(id);
            return Mapper.Map<ChamadoVM>(chamado);
        }

        public async Task<IList<ChamadoIndexVM>> Obter5RecentesPorUsuarioAsync(long usuarioId)
        {
            var chamados = await chamadoService.Obter5RecentesPorUsuarioAsync(usuarioId);
            return await Task.Run(() => Mapper.Map<IList<ChamadoIndexVM>>(chamados));
        }

        public async Task<HomeVM> ObterHomeVMAsync(long usuarioId)
        {
            var chamadosAtualizadosRecente = await chamadoService.Obter5RecentesPorUsuarioAsync(usuarioId);
            var chamadosEmAberto = await chamadoService.Obter5EmAbertoAsync(usuarioId);

            return await Task.Run((() =>
            {
                var model = new HomeVM
                {
                    ChamadosEmAberto = Mapper.Map<IEnumerable<CommonDTO>>(chamadosEmAberto),
                    ChamadosAtualizados = Mapper.Map<IEnumerable<CommonDTO>>(chamadosAtualizadosRecente)
                };

                return model;
            }));
        }
    }
}
