using System.Collections.Generic;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Repositories;
using SistemaDeChamados.Domain.Interfaces.Services;
using SistemaDeChamados.Domain.VO;

namespace SistemaDeChamados.Domain.Services
{
    public class PerfilService : ServiceBase<Perfil>, IPerfilService
    {
        private readonly IPerfilRepository perfilRepository;

        public PerfilService(IPerfilRepository perfilRepository) : base(perfilRepository)
        {
            this.perfilRepository = perfilRepository;
        }

        public IEnumerable<AcessoVO> TodosAcessosDePerfil()
        {
            return new List<AcessoVO>
            {
                new AcessoVO("usercrud", "Acesso ao controle de usuários", "Usuarios", "*", "Usuários"),
                new AcessoVO("setcrud", "Acesso ao controle de setor", "Setores", "*", "Setores"),
                new AcessoVO("setperf", "Acesso ao controle de perfil", "Perfil", "*", "Perfis"),
                new AcessoVO("all", "Todos os acessos", "*", "*", "*"),
                new AcessoVO("suporte", "Acesso ao suporte do sistema", "Suporte", "*", "Suporte"),
                new AcessoVO("relatorios", "Acesso aos relatórios do sistema", "Relatorios", "*", "Relatórios")
            };
        }

        public static IEnumerable<AcessoVO> TodosAcessosDoSistema()
        {
            return new List<AcessoVO>
            {
                new AcessoVO("usercrud", "Acesso ao controle de usuários", "Usuarios", "*", "Usuários"),
                new AcessoVO("setcrud", "Acesso ao controle de setor", "Setores", "*", "Setores"),
                new AcessoVO("setperf", "Acesso ao controle de perfil", "Perfil", "*", "Perfis"),
                new AcessoVO("all", "Todos os acessos", "*", "*", "*"),
                new AcessoVO("suporte", "Acesso ao suporte do sistema", "Suporte", "*", "Suporte"),
                new AcessoVO("relatorios", "Acesso aos relatórios do sistema", "Relatorios", "*", "Relatórios")
            };
        } 
    }
}
