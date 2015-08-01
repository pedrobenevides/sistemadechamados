using System;

namespace SistemaDeChamados.Domain.Exceptions
{
    public class ServiceException : ChamadosException
    {
        public ServiceException(string message)
            :base(message)
        { }
    }
}
