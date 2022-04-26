using AutoMapper;

namespace DataAccess.Automapper
{
    public class EntityMappingProfile : Profile
    {
        public EntityMappingProfile()
        {
            CreateMap<DomainModels.CurrencyDefinition, Entities.Currency>()
                .ForMember(x => x.Id, f => f.Ignore())
                .ForMember(x => x.ProviderId, f => f.MapFrom(d => d.Id))
                .ForMember(x => x.Name, f => f.MapFrom(d => d.Name))
                .ForMember(x => x.Symbol, f => f.MapFrom(d => d.Symbol))
                .ForMember(x => x.ProviderLastUpdatedDate, f => f.Ignore())
                .ForMember(x => x.RecordUpdatedDate, f => f.Ignore());
                
        }
    }
}
