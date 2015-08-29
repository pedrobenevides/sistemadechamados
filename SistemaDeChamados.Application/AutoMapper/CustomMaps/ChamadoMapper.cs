using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces;

namespace SistemaDeChamados.Application.AutoMapper.CustomMaps
{
    public class ChamadoMapper : Profile
    {
        private readonly IColaboradorAppService colaboradorAppService;

        public ChamadoMapper()
        {
            colaboradorAppService = ServiceLocator.Current.GetInstance<IColaboradorAppService>();
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Chamado, ChamadoIndexVM>()
                .ForMember(m => m.NomeDoColaborador, exp => exp.ResolveUsing(ObterNomeDoColaborador))
                //.ForMember(m => m.NomeDoAnalista, exp => exp.ResolveUsing(ObterNomeDoAnalista))
                .ForMember(m => m.DiasEmAberto, exp => exp.MapFrom(c => c.NumeroDeDiasUteis(ServiceLocator.Current.GetInstance<ICalculateDate>())));
        }

        private object ObterNomeDoColaborador(Chamado chamado)
        {
            return colaboradorAppService.ObterNomeDoColaboradorPorId(chamado.ColaboradorId);
        }
        private object ObterNomeDoAnalista(Chamado chamado)
        {
            return colaboradorAppService.ObterNomeDoColaboradorPorId(chamado.ColaboradorId);
        }
    }
}
