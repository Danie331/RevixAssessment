using DataAccess.Contract;
using DataAccess.Core;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class DependencyRegistration
    {
        public static void RegisterRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRatesDataRepository, RatesDataRepository>();
            services.AddDbContext<MarketRatesContext>(options => options.UseSqlServer(configuration.GetConnectionString("MarketRates")));
        }
    }
}
