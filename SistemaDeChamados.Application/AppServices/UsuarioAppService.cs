using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.DTO;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Application.AppServices
{
    public class UsuarioAppService : AppService, IUsuarioAppService
    {
        private readonly IUsuarioService usuarioService;
        private readonly IPerfilService perfilService;

        public UsuarioAppService(IUsuarioService usuarioService, IPerfilService perfilService)
        {
            this.usuarioService = usuarioService;
            this.perfilService = perfilService;
        }
        
        public IEnumerable<ColaboradorVM> Retrieve()
        {
            var listaDeUsuario = usuarioService.Obter();
            return Mapper.Map<IEnumerable<Usuario>, IEnumerable<ColaboradorVM>>(listaDeUsuario.ToList());
        }
        
        public void Delete(long id)
        {
            BeginTransaction();
            usuarioService.Delete(id);
            Commit();
        }

        public ColaboradorVM GetById(long id)
        {
            var usuario = usuarioService.GetById(id);
            return Mapper.Map<Usuario, ColaboradorVM>(usuario); 
        }

        public IEnumerable<ColaboradorVM> ObterReadOnly()
        {
            var listaDeUsuario = usuarioService.ObterReadOnly();
            return Mapper.Map<IEnumerable<Usuario>, IEnumerable<ColaboradorVM>>(listaDeUsuario.ToList());
        }
        
        public virtual UsuarioLogadoVM ObterUsuarioLogado(LoginVM loginVM)
        {
            var usuario = usuarioService.ValidaSenhaInformada(loginVM.Login, loginVM.Senha);
            var usuarioLogadoVM = Mapper.Map<UsuarioLogadoVM>(usuario);
            var colaborador = usuario as Colaborador;
            
            if (colaborador != null && colaborador.PerfilId.HasValue)
                usuarioLogadoVM.Perfil = perfilService.GetById(colaborador.PerfilId.Value);

            return usuarioLogadoVM;
        }

        public void AlterarStatus(long id)
        {
            BeginTransaction();
            usuarioService.AlterarStatus(1);
            Commit();
        }

        public void AtualizarSenha(ColaboradorVM colaborador)
        {
            BeginTransaction();
            usuarioService.AtualizarSenha(Mapper.Map<UsuarioSenhaDTO>(colaborador));
            Commit();
        }
    }
}
