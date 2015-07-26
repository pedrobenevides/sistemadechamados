﻿using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.Interface.Socket;

namespace SistemaDeChamados.Application.SignalR
{
    public class SistemaHub : Hub, ISistemaHub
    {
        private readonly IUsuarioAppService usuarioAppService;

        public SistemaHub(IUsuarioAppService usuarioAppService)
        {
            this.usuarioAppService = usuarioAppService;
        }

        public void Comunicar(string nome, string menssagem)
        {
            var contextoHub = GlobalHost.ConnectionManager.GetHubContext<SistemaHub>();
            contextoHub.Clients.Group(nome).All.addNewMessage(nome, menssagem);
        }

        public Task AdicionarAoGrupo(string nomeDoGrupo)
        {
            return Groups.Add(Context.ConnectionId, nomeDoGrupo);
        }

        public override Task OnConnected()
        {
            var claims = (ClaimsIdentity)Context.User.Identity;
            var setor = claims.Claims.FirstOrDefault(c => c.Type == ClaimTypes.System);

            Groups.Add(Context.ConnectionId, setor.Value);

            return base.OnConnected();
        }
    }
}
