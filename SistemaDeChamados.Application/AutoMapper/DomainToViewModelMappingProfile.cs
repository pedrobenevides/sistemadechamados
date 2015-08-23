using System.Collections.Generic;
using AutoMapper;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.DTO;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Mensagem, MensagemVM>();
            Mapper.CreateMap<Chamado, ChamadoVM>();
            Mapper.CreateMap<Usuario, UsuarioVM>();
            Mapper.CreateMap<Colaborador, UsuarioVM>();
            Mapper.CreateMap<UsuarioDTO, UsuarioVM>();
            Mapper.CreateMap<UsuarioSenhaDTO, UsuarioVM>();
            Mapper.CreateMap<Colaborador, UsuarioLogadoVM>().ForMember(vm => vm.Setor, expr => expr.MapFrom(u => u.Setor.Nome));
            Mapper.CreateMap<Setor, SetorVM>();
            Mapper.CreateMap<Perfil, PerfilVM>();
            Mapper.CreateMap<Categoria, CategoriaVM>();
        }
    }
}
