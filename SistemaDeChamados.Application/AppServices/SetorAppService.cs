﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.Interface.Services;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Exceptions;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Application.AppServices
{
    public class SetorAppService : AppService, ISetorAppService
    {
        private readonly ISetorService setorService;

        public SetorAppService(ISetorService setorService, IServiceLocator serviceLocator)
            : base(serviceLocator)
        {
            this.setorService = setorService;
        }

        public IEnumerable<Setor> ObterTodosOsSetores()
        {
            return setorService.Obter();
        }

        public SetorVM ObterPorUsuarioId(long usuarioId)
        {
            var setor = setorService.ObterPorUsuarioId(usuarioId);
            return Mapper.Map<SetorVM>(setor);
        }

        public string ObterNomeDoSetorPorId(long setorId)
        {
            var setor = setorService.GetById(setorId);

            if(setor == null)
                throw new ChamadosException("Setor inexistente.");

            return setor.Nome;
        }

        public async Task<string> ObterNomeDoSetorPorIdAsync(long setorId)
        {
            var setor = await setorService.GetByIdAsync(setorId);

            if (setor == null)
                throw new ChamadosException("Setor inexistente.");

            return setor.Nome; ;
        }
    }
}
