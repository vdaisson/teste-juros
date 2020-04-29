using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxaJuros.Domain.Configurations;
using TaxaJuros.Domain.Interfaces.Configurations;
using TaxaJuros.Domain.Interfaces.Repositories;
using TaxaJuros.Domain.Service.Interfaces;
using TaxaJuros.Domain.Service.Services;
using TaxaJuros.Infrastructure.Data.Repositories.TaxaJuros;

namespace TaxaJuros.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddTaxaJurosServices(this IServiceCollection services)
        {
            services.AddTransient<ITaxaJurosRepository, TaxaJurosRepository>();
            services.AddTransient<ITaxaJurosService, TaxaJurosService>();

            services.AddSingleton<ITaxaJurosConfiguration, TaxaJurosConfiguration>(provider => provider
                .GetService<IConfiguration>()
                .GetSection("TaxaJurosConfiguration")
                .Get<TaxaJurosConfiguration>());
        }
    }
}
