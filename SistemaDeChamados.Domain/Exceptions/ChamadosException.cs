using System;

namespace SistemaDeChamados.Domain.Exceptions
{
    [Serializable]
    public class ChamadosException : Exception
    {
        public ChamadosException(string menssagem)
            :base(menssagem)
        { }
    }
}
