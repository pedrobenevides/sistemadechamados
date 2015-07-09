using System;

namespace SistemaDeChamados.Domain.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException(string message)
            :base(message)
        { }
    }
}
