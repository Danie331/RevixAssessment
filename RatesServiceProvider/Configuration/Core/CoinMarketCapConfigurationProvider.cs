using DomainModels.Configuration;
using Microsoft.Extensions.Options;
using ExternalServiceProviders.Configuration.Contract;

namespace ExternalServiceProviders.Configuration.Core
{
    public class CoinMarketCapConfigurationProvider : IRatesServiceConfigurationProvider
    {
        private readonly IOptions<RatesServiceProviderSettings> _settings;
        public CoinMarketCapConfigurationProvider(IOptions<RatesServiceProviderSettings> settings)
        {
            _settings = settings;
        }

        public string BaseAddress => _settings.Value.BaseAddress;

        public string ApiKey => _settings.Value.ApiKey;
    }
}
