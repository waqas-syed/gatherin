using AutoMapper;

namespace Gatherin.Presentation.Mappings
{
    /// <summary>
    /// Configuration for the AutoMapper
    /// </summary>
    public class AutoMapperConfiguration
    {
        public static void Confirue()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}