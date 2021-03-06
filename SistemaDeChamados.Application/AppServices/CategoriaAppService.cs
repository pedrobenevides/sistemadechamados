﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.Interface.Services;
using SistemaDeChamados.Domain.DTO;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Application.AppServices
{
    public class CategoriaAppService : AppService, ICategoriaAppService
    {
        private readonly ICategoriaService categoriaService;

        public CategoriaAppService(ICategoriaService categoriaService, IServiceLocator serviceLocator)
            : base(serviceLocator)
        {
            this.categoriaService = categoriaService;
        }

        public IEnumerable<Categoria> ObterTodasCategorias()
        {
            return categoriaService.Obter();
        }

        public IEnumerable<CommonDTO> ObterPorSetor(long setorId)
        {
            return categoriaService.ObterPorSetor(setorId);
        }

        public async Task<IEnumerable<Categoria>> ObterPorSetorAsync(long setorId)
        {
            return await categoriaService.ObterPorSetorAsync(setorId);
        }
    }
}
