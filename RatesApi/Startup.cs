using AutoMapper;
using DomainModels.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RatesApi.Middleware;
using RatesService;

namespace RatesApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterServices(Configuration);

            services.AddControllers()
                   .AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null)
                   .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddAutoMapper(GetType().Assembly, typeof(DataAccess.Automapper.EntityMappingProfile).Assembly,
                typeof(ExternalServiceProviders.Automapper.DtoMappingProfile).Assembly);

            services.AddSwaggerDocument(settings => settings.Title = "Revix assessment :: Rates service");

            //
            // Can alternatively inject an IConfigurationRoot directly into the dependent class
            //
            services.Configure<RatesServiceProviderSettings>(Configuration.GetSection("RatesServiceProvider"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }

            var builder = new ConfigurationBuilder()
                        .SetBasePath(env.ContentRootPath)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                        .AddEnvironmentVariables()
                        .Build();

            app.UseRouting();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}