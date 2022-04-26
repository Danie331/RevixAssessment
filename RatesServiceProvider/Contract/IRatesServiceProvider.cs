using DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExternalServiceProviders.Contract
{
    public interface IRatesServiceProvider
    {
        Task<IEnumerable<CurrencyDefinition>> GetCurrenciesAsync();
        Task<IEnumerable<CurrencyPair>> GetLatestMarketQuotesAsync();
        Task<IEnumerable<CurrencyPair>> GetLatestMarketQuotesAsync(int providerId);
        Task<IEnumerable<CurrencyPair>> GetLatestMarketQuotesAsync(string symbol);
    }
}
