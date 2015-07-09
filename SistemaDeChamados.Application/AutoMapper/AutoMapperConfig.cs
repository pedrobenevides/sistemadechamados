using AutoMapper;

namespace SistemaDeChamados.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(m =>
            {
                m.AddProfile<DomainToViewModelMappingProfile>();
                m.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}
