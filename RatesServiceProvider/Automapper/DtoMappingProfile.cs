using AutoMapper;

namespace ExternalServiceProviders.Automapper
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<Models.Currency, DomainModels.CurrencyDefinition>();
        }
    }
}
