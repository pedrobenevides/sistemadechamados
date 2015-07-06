﻿using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Repositories;

namespace SistemaDeChamados.Infra.Data.Repositories
{
    public class ChamadoRepository : RepositoryBase<Chamado>, IChamadoRepository
    {
    }
}
