using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Repositories;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Domain.Services
{
    public class ArquivoService : ServiceBase<Arquivo>, IArquivoService
    {
        public ArquivoService(IArquivoRepository repository)
            : base(repository)
        {
        }

        public async Task SalvarArquivosFisicos(IList<Arquivo> arquivosStreams, long chamadoId)
        {
            var caminho = string.Format("{0}/Anexos/{1}", AppDomain.CurrentDomain.BaseDirectory, chamadoId);

            Directory.CreateDirectory(caminho);

            foreach (var arquivo in arquivosStreams)
            {
                using (var fileStream = File.Create(string.Format("{0}/{1}", caminho, arquivo.Filename)))
                {
                    arquivo.Stream.Seek(0, SeekOrigin.Begin);
                    await arquivo.Stream.CopyToAsync(fileStream);
                }
            }
        }
    }
}
