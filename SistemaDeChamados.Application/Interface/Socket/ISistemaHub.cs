﻿using System.Threading.Tasks;

namespace SistemaDeChamados.Application.Interface.Socket
{
    public interface ISistemaHub
    {
        void Comunicar(string nome, string menssagem);
        Task AdicionarAoGrupo(string nomeDoGrupo);
    }
}