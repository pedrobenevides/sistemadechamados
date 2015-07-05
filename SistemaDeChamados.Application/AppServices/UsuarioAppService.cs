using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Application.AppServices
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        public void Create(UsuarioVM usuarioVM)
        {
            var usuario = Mapper.Map<UsuarioVM, Usuario>(usuarioVM);
            usuarioService.Create(usuario);
        }

        public IEnumerable<UsuarioVM> Retrieve()
        {
            var listaDeUsuario = usuarioService.Retrieve();
            return Mapper.Map<IList<Usuario>, IList<UsuarioVM>>(listaDeUsuario.ToList());
        }

        public void Update(UsuarioVM usuarioVM)
        {
            var usuario = Mapper.Map<UsuarioVM, Usuario>(usuarioVM);
            usuarioService.Update(usuario);
        }

        public void Delete(long id)
        {
            usuarioService.Delete(id);
        }

        public UsuarioVM GetById(long id)
        {
            var usuario = usuarioService.GetById(id);
            return Mapper.Map<Usuario, UsuarioVM>(usuario); 
        }
    }
}
