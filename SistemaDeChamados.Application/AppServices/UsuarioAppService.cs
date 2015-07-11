using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Application.AppServices
{
    public class UsuarioAppService : AppService, IUsuarioAppService
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        public void Create(UsuarioVM usuarioVM)
        {
            var usuario = Mapper.Map<UsuarioVM, Usuario>(usuarioVM);
            BeginTransaction();
            usuarioService.Create(usuario);
            Commit();
        }

        public IEnumerable<UsuarioVM> Retrieve()
        {
            var listaDeUsuario = usuarioService.Retrieve();
            return Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioVM>>(listaDeUsuario.ToList());
        }

        public void Update(UsuarioVM usuarioVM)
        {
            var usuario = Mapper.Map<UsuarioVM, Usuario>(usuarioVM);
            BeginTransaction();
            usuarioService.Update(usuario);
            Commit();
        }

        public void Delete(long id)
        {
            BeginTransaction();
            usuarioService.Delete(id);
            Commit();
        }

        public UsuarioVM GetById(long id)
        {
            var usuario = usuarioService.GetById(id);
            return Mapper.Map<Usuario, UsuarioVM>(usuario); 
        }
    }
}
