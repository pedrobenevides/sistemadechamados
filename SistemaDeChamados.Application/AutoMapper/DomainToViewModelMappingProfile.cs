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
            Mapper.CreateMap<UsuarioDTO, UsuarioVM>();
            Mapper.CreateMap<UsuarioSenhaDTO, UsuarioVM>();
            Mapper.CreateMap<Usuario, UsuarioLogadoVM>();
        }
    }
}
