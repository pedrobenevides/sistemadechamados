﻿using System.Threading.Tasks;

namespace SistemaDeChamados.Application.Interface
{
    public interface IAppService
    {
        void BeginTransaction();
        void Commit();
        Task CommitAsync();
    }
}