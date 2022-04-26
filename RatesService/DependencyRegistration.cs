using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RatesService.Contract;
using RatesService.Core;

namespace RatesService
{
    public static class DependencyRegistration
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRatesService, MarketRatesService>();

            ExternalServiceProviders.DependencyRegistration.RegisterExternalServices(services, configuration);
            DataAccess.DependencyRegistration.RegisterRepository(services, configuration);
        }
    }
}
