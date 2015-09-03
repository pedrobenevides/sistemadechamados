using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Exceptions;
using SistemaDeChamados.Domain.Interfaces;

namespace SistemaDeChamados.Application.AutoMapper.CustomMaps
{
    public class ChamadoMapper : Profile
    {
        private readonly IColaboradorAppService colaboradorAppService;
        private readonly IAnalistaAppService analistaAppService;

        public ChamadoMapper()
        {
            colaboradorAppService = ServiceLocator.Current.GetInstance<IColaboradorAppService>();
            analistaAppService = ServiceLocator.Current.GetInstance<IAnalistaAppService>();
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Chamado, ChamadoIndexVM>()
                .ForMember(m => m.NomeDoColaborador, exp => exp.ResolveUsing(ObterNomeDoColaborador))
                .ForMember(m => m.NomeDoAnalista, exp => exp.ResolveUsing(ObterNomeDoAnalista))
                .ForMember(m => m.DiasEmAberto, exp => exp.MapFrom(c => c.NumeroDeDiasUteis(ServiceLocator.Current.GetInstance<ICalculateDate>())));
        }

        private object ObterNomeDoColaborador(Chamado chamado)
        {
            return colaboradorAppService.ObterNomeDoColaboradorPorId(chamado.ColaboradorId);
        }

        private object ObterNomeDoAnalista(Chamado chamado)
        {
            if(!chamado.Categoria.AnalistaId.HasValue)
                throw new ChamadosException(string.Format("A categoria {0} do chamado {1}, não possui analista, favor verificar com o suporte.", chamado.Categoria.Id, chamado.Id));

            return analistaAppService.ObterNomePorId(chamado.Categoria.AnalistaId.Value);
        }
    }
}
