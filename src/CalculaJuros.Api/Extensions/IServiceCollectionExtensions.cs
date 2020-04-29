using Microsoft.Extensions.DependencyInjection;
using CalculaJuros.Domain.Interfaces;
using CalculaJuros.Domain.Service.Interfaces;
using CalculaJuros.Domain.Service.Services;
using CalculaJuros.Domain.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace CalculaJuros.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddCalculaJurosServices(this IServiceCollection services)
        {
            services.AddTransient<ICalculaJuros, Domain.CalculaJuros>();
            services.AddTransient<ICalculaJurosService, CalculaJurosService>();
            services.AddTransient<ITaxaJurosApiService, TaxaJurosApiService>();

            services.AddSingleton<ICalculaJurosConfiguration, CalculaJurosConfiguration>(provider => provider
                .GetService<IConfiguration>()
                .GetSection("CalculaJurosConfiguration")
                .Get<CalculaJurosConfiguration>());
        }
    }
}
