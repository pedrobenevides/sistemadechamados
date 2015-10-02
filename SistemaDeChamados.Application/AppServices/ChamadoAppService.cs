using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.Interface.Services;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.DTO;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Enums;
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

        public async Task CreateAsync(CriacaoChamadoVM chamadoVM)
        {
            var chamado = Mapper.Map<Chamado>(chamadoVM);
            chamado.Arquivos = Mapper.Map<IList<Arquivo>>(chamadoVM.Anexos);

            //Não é usado BeginTransaction porque o commit é feito manualmente para obter o id do chamado.
            await chamadoService.CreateComAnexosAsync(chamado);
        }

        public IEnumerable<ChamadoIndexVM> Retrieve()
        {
            var listaDeChamados = chamadoService.Obter();
            return Mapper.Map<IList<ChamadoIndexVM>>(listaDeChamados.ToList());
        }

        public VisualizarChamadoVM GetCompleteById(long id)
        {
            var chamado = chamadoService.GetById(id);
            var chamadoVm = Mapper.Map<VisualizarChamadoVM>(chamado);
            chamadoVm.NovaMensagem.ChamadoId = id;

            return chamadoVm;
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

        public void AlterarStatus(long chamadoId, long usuarioId, StatusDoChamado statusNovo)
        {
            chamadoService.AlterarStatus(chamadoId, usuarioId, statusNovo);
        }

        public async Task AlterarStatusAsync(long id, long usuarioId, string status)
        {
            BeginTransaction();
            await chamadoService.AlterarStatusAsync(id, usuarioId, status);
            await CommitAsync();
        }
    }
}
