﻿using System.Collections.Generic;
using System.Threading.Tasks;
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
            Mapper.CreateMap<Chamado, ChamadoVM>();
            Mapper.CreateMap<Usuario, ColaboradorVM>();
            Mapper.CreateMap<Colaborador, ColaboradorVM>();
            Mapper.CreateMap<UsuarioDTO, ColaboradorEdicaoVM>();
            Mapper.CreateMap<UsuarioSenhaDTO, ColaboradorVM>();
            Mapper.CreateMap<ColaboradorDTO, ColaboradorVM>();
            Mapper.CreateMap<Colaborador, UsuarioLogadoVM>().ForMember(vm => vm.Setor, expr => expr.MapFrom(u => u.Setor.Nome));
            Mapper.CreateMap<Analista, AnalistaVM>();
            Mapper.CreateMap<Analista, UsuarioLogadoVM>();
            Mapper.CreateMap<Setor, SetorVM>();
            Mapper.CreateMap<Perfil, PerfilVM>();

            //Assíncronos
            Mapper.CreateMap<Task<IEnumerable<Analista>>, Task<IEnumerable<AnalistaVM>>>();
        }
    }
}
