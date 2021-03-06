﻿using System;

namespace SistemaDeChamados.Domain.Entities
{
    public class Mensagem
    {
        public Mensagem(string texto, long usuarioId, long chamadoId)
        {
            Texto = texto;
            DataDeCriacao = DateTime.Now;
            UsuarioId = usuarioId;
            ChamadoId = chamadoId;
        }

        protected Mensagem()
        {
            DataDeCriacao = DateTime.Now;
        }

        public long Id { get; private set; }
        public DateTime DataDeCriacao { get; private set; }
        public string Texto { get; private set; }
        public long ChamadoId { get; private set; }
        public long UsuarioId { get; private set; }
        public DateTime? DataDaLeitura { get; private set; }

        public void ConfirmarLeitura(long usuarioLeitorId)
        {
            if(usuarioLeitorId != UsuarioId)
                DataDaLeitura = DateTime.Now;
        }
    }
}
