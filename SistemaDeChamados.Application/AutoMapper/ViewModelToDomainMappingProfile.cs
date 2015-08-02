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
            Mapper.CreateMap<UsuarioVM, Usuario>();
            Mapper.CreateMap<UsuarioVM, UsuarioSenhaDTO>();
            Mapper.CreateMap<PerfilVM, Perfil>();
            Mapper.CreateMap<CategoriaVM, Categoria>();
        }
    }
}
