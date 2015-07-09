using System.Security.Cryptography;
using System.Text;
using SistemaDeChamados.Domain.Exceptions;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Domain.Services
{
    public class CriptografadorDeSenhaMD5 : ICriptografadorDeSenha
    {
        public string CriptografarSenha(string senhaPlainText)
        {
            if(string.IsNullOrEmpty(senhaPlainText))
                throw new CriptografadorException("Senha informada está nula ou em branco");

            var md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.ASCII.GetBytes(senhaPlainText));

            var resultado = md5.Hash;

            var stringBuilder = new StringBuilder();
            
            foreach (var t in resultado)
                stringBuilder.Append(t.ToString("x2"));

            return stringBuilder.ToString();
        }
    }
}
