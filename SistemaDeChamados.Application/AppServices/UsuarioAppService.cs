using System.Collections.Generic;
using System.Linq;
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
    public class UsuarioAppService : AppService, IUsuarioAppService
    {
        private readonly IUsuarioService usuarioService;
        private readonly IPerfilService perfilService;

        public UsuarioAppService(IUsuarioService usuarioService, IPerfilService perfilService, IServiceLocator serviceLocator)
            : base(serviceLocator)
        {
            this.usuarioService = usuarioService;
            this.perfilService = perfilService;
        }
        
        public virtual IEnumerable<ColaboradorVM> Retrieve()
        {
            var listaDeUsuario = usuarioService.Obter();
            return Mapper.Map<IEnumerable<Usuario>, IEnumerable<ColaboradorVM>>(listaDeUsuario.ToList());
        }
        
        public virtual void Delete(long id)
        {
            BeginTransaction();
            usuarioService.Delete(id);
            Commit();
        }

        public virtual ColaboradorVM GetById(long id)
        {
            var usuario = usuarioService.GetById(id);
            return Mapper.Map<Usuario, ColaboradorVM>(usuario); 
        }

        public virtual IEnumerable<ColaboradorVM> ObterReadOnly()
        {
            var listaDeUsuario = usuarioService.ObterReadOnly();
            return Mapper.Map<IEnumerable<Usuario>, IEnumerable<ColaboradorVM>>(listaDeUsuario.ToList());
        }
        
        public virtual UsuarioLogadoVM ObterUsuarioLogado(LoginVM loginVM)
        {
            var usuario = usuarioService.ValidaSenhaInformada(loginVM.Login, loginVM.Senha);
            var usuarioLogadoVM = Mapper.Map<UsuarioLogadoVM>(usuario);
            

            if (usuario is Colaborador)
            {
                var colaborador = usuario as Colaborador;

                usuarioLogadoVM.Perfil = colaborador.PerfilId.HasValue
                    ? perfilService.GetById(colaborador.PerfilId.Value)
                    : null;

                usuarioLogadoVM.TipoUsuario = TipoUsuario.Comum;

                return usuarioLogadoVM;
            }

            usuarioLogadoVM.TipoUsuario = TipoUsuario.Analista;

            return usuarioLogadoVM;
        }

        public virtual void AlterarStatus(long id)
        {
            BeginTransaction();
            usuarioService.AlterarStatus(id);
            Commit();
        }

        public virtual void AtualizarSenha(ColaboradorVM colaborador)
        {
            BeginTransaction();
            usuarioService.AtualizarSenha(Mapper.Map<UsuarioSenhaDTO>(colaborador));
            Commit();
        }
    }
}
