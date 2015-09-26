using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.DTO;
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

            Mapper.CreateMap<Chamado, CommonDTO>()
                .ForMember(c => c.Id, exp => exp.MapFrom(c => c.Id))
                .ForMember(c => c.Nome, exp => exp.MapFrom(c => c.Titulo));

            Mapper.CreateMap<Chamado, VisualizarChamadoVM>()
                .ForMember(m => m.NomeColaborador, exp => exp.ResolveUsing(ObterNomeDoColaborador))
                .ForMember(m => m.NumeroDeMensagens, exp => exp.ResolveUsing(ObterNumeroDeMensagensDoChamado))
                .ForMember(m => m.Mensagens, exp => exp.ResolveUsing(Obter5UltimasMensagens))
                .ForMember(m => m.NomeAnalista, exp => exp.ResolveUsing(ObterNomeDoAnalista));
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

        private object ObterNumeroDeMensagensDoChamado(Chamado chamado)
        {
            return chamado.Mensagens.Count;
        }

        private object Obter5UltimasMensagens(Chamado chamado)
        {
            return chamado.Mensagens.Take(5);
        }
    }
}
