using AutoMapper;

namespace RatesApi.Automapper
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile() 
        {
            CreateMap<DomainModels.CurrencyDefinition, Dto.Currency>()
                .ForMember(x => x.ProviderId, g => g.MapFrom(f => f.Id))
                .ForMember(x => x.ProviderName, g => g.MapFrom(f => f.Name))
                .ForMember(x => x.ProviderSymbol, g => g.MapFrom(f => f.Symbol));

            CreateMap<DomainModels.CurrencyPair, Dto.CurrencyPair>()
                .ForMember(s => s.BaseCurrencyId, j => j.MapFrom(b => b.BaseCurrency.Id))
                .ForMember(s => s.BaseCurrencyName, j => j.MapFrom(b => b.BaseCurrency.Name))
                .ForMember(s => s.BaseCurrencySymbol, j => j.MapFrom(b => b.BaseCurrency.Symbol))
                .ForMember(s => s.QuotedCurrencyId, j => j.MapFrom(b => b.QuotedCurrency.Id))
                .ForMember(s => s.QuotedCurrencyName, j => j.MapFrom(b => b.QuotedCurrency.Name))
                .ForMember(s => s.QuotedCurrencySymbol, j => j.MapFrom(b => b.QuotedCurrency.Symbol))
                .ForMember(s => s.Price, j => j.MapFrom(b => b.Price));
        }
    }
}
