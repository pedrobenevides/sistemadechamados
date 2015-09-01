namespace SistemaDeChamados.Domain.VO
{
    public class AcessoVO
    {
        public AcessoVO(string chave, string descricao, string controller, string action, string nomeAmigavel)
        {
            Chave = chave;
            Descricao = descricao;
            Controller = controller;
            Action = action;
            NomeAmigavel = nomeAmigavel;
        }

        public string Chave { get; set; }
        public string Descricao { get; private set; }
        public string Controller { get; private set; }
        public string Action { get; private set; }
        public string NomeAmigavel { get; private set; }
    }
}
