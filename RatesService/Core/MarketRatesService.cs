using DomainModels;
using RatesService.Contract;
using ExternalServiceProviders.Contract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Contract;

namespace RatesService.Core
{
    public class MarketRatesService : IRatesService
    {
        private readonly IRatesServiceProvider _ratesServiceProvider;
        private readonly IRatesDataRepository _ratesDataRepository;

        public MarketRatesService(IRatesServiceProvider ratesServiceProvider, IRatesDataRepository ratesDataRepository)
        {
            _ratesServiceProvider = ratesServiceProvider;
            _ratesDataRepository = ratesDataRepository;
        }

        public async Task<IEnumerable<CurrencyDefinition>> GetCurrenciesAsync()
        {
            var currencies = await _ratesServiceProvider.GetCurrenciesAsync();

            await _ratesDataRepository.AddCurrenciesAsync(currencies);

            return currencies;
        }

        public async Task<IEnumerable<CurrencyPair>> GetMarketRatesAsync()
        {
            var currencyRates = await _ratesServiceProvider.GetLatestMarketQuotesAsync();
            return currencyRates;
        }

        public async Task<IEnumerable<CurrencyPair>> GetMarketRatesAsync(int providerCurrencyId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CurrencyPair>> GetMarketRatesAsync(string providerCurrencySymbol)
        {
            throw new NotImplementedException();
        }
    }
}
