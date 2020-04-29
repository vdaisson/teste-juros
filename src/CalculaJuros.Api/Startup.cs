using CalculaJuros.Api.Extensions;
using CalculaJuros.Domain.Configurations;
using CalculaJuros.Domain.Interfaces;
using CalculaJuros.Domain.Service.Interfaces;
using CalculaJuros.Domain.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace CalculaJuros.Api
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IWebHostEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{_env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);

            services.AddControllers();

            if (_env.IsProduction())
            {
                AddProductionCalculaJurosServices(services);
            }
            else
            {
                services.AddCalculaJurosServices();
            }
            
            services.AddHttpClient();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CalculaJurosApi", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        private void AddProductionCalculaJurosServices(IServiceCollection services)
        {
            services.AddTransient<ICalculaJuros, Domain.CalculaJuros>();
            services.AddTransient<ICalculaJurosService, CalculaJurosService>();
            services.AddTransient<ITaxaJurosApiService, TaxaJurosApiService>();

            services.AddSingleton<ICalculaJurosConfiguration, CalculaJurosConfiguration>(provider =>
            {
                return new CalculaJurosConfiguration
                {
                    Culture = Configuration.GetValue<string>("CALCULAJUROS_CULTURE"),
                    TaxaJurosApiUrl = Configuration.GetValue<string>("CALCULAJUROS_TAXAJUROSAPIURL"),
                    ShowMeTheCodeUrl = Configuration.GetValue<string>("CALCULAJUROS_SHOWMETHECODEURL")
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CalculaJurosApi V1");
            });
        }
    }
}
