using AutoMapper;
using SistemaDeChamados.Application.ViewModels;
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
        }
    }
}
