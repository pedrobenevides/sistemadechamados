using System;
using System.Web;
using AutoMapper;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.DTO;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<MensagemVM, Mensagem>();
            Mapper.CreateMap<ChamadoVM, Chamado>();
            Mapper.CreateMap<CriacaoChamadoVM, Chamado>()
                .ForMember(x => x.ColaboradorId, opt => opt.MapFrom(c => c.UsuarioId))
                .ForMember(x => x.DataDeCriacao, opt => opt.UseValue(DateTime.Now));
            Mapper.CreateMap<ColaboradorVM, Usuario>();
            Mapper.CreateMap<ColaboradorVM, Colaborador>();
            Mapper.CreateMap<ColaboradorEdicaoVM, Colaborador>();
            Mapper.CreateMap<ColaboradorVM, UsuarioSenhaDTO>();
            Mapper.CreateMap<PerfilVM, Perfil>();
            Mapper.CreateMap<CategoriaVM, Categoria>();
            Mapper.CreateMap<HttpPostedFileBase, Arquivo>()
                .ForMember(a => a.Tamanho, opt => opt.MapFrom(f => f.ContentLength));
        }
    }
}
