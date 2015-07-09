using System;

namespace SistemaDeChamados.Domain.Exceptions
{
    public class CriptografadorException : Exception
    {
        public CriptografadorException(string mensagem)
            :base(mensagem)
        { }

        public CriptografadorException(string mensagem, Exception innerException)
            :base(mensagem, innerException)
        { }
    }
}
