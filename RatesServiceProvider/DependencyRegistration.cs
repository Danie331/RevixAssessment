using DataAccess.Contract;
using DataAccess.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ExternalServiceProviders.Contract;
using ExternalServiceProviders.Core;
using ExternalServiceProviders.Configuration.Contract;
using ExternalServiceProviders.Configuration.Core;

namespace ExternalServiceProviders
{
    public static class DependencyRegistration
    {
        public static void RegisterExternalServices(this IServiceCollection services, IConfiguration _)
        {
            services.AddHttpClient<IRatesServiceProvider, CoinMarketCapServiceProvider>();
            services.AddScoped<IRatesDataRepository, RatesDataRepository>();
            services.AddScoped<IRatesServiceConfigurationProvider, CoinMarketCapConfigurationProvider>();
        }
    }
}
