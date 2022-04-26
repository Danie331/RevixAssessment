using DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RatesService.Contract
{
    public interface IRatesService
    {
        Task<IEnumerable<CurrencyDefinition>> GetCurrenciesAsync();
        Task<IEnumerable<CurrencyPair>> GetMarketRatesAsync();
        Task<IEnumerable<CurrencyPair>> GetMarketRatesAsync(int providerCurrencyId);
        Task<IEnumerable<CurrencyPair>> GetMarketRatesAsync(string providerCurrencySymbol);
    }
}
