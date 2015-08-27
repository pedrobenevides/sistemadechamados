namespace SistemaDeChamados.Application.Identity
{
    /// <summary>
    /// Todas as Claims customizadas devem ser criadas aqui.
    /// </summary>
    public static class CustomClaimTypes
    {
        public static string Acoes { get { return "Acoes"; } }
        public static string Setor { get { return "Setor"; } }
        public static string Id { get { return "Id"; } }
    }
}