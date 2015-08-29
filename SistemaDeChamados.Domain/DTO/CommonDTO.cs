namespace SistemaDeChamados.Domain.DTO
{
    public class CommonDTO
    {
        public CommonDTO(long id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public CommonDTO()
        { }

        public long Id { get; set; }
        public string Nome { get; set; }
    }
}
