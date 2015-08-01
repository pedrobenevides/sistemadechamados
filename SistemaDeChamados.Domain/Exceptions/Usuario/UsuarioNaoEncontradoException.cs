namespace SistemaDeChamados.Domain.Exceptions.Usuario
{
    public class UsuarioNaoEncontradoException : ChamadosException
    {
        public UsuarioNaoEncontradoException()
            :base("Usuário não existe na base de dados")
        { }

        public UsuarioNaoEncontradoException(string mensagem) : 
            base(mensagem)
        { }
    }
}
