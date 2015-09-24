 namespace SistemaDeChamados.Application.ViewModels
{
    public class PaggingVM
    {
        public PaggingVM(string controller)
        {
            Controller = controller;
            PaginaAtual = 1;
        }

        public string Controller { get; set; }
        public int PaginaAtual { get; set; }
    }
}
