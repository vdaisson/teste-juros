using CalculaJuros.Domain.Interfaces;
using CalculaJuros.Domain.Service.Interfaces;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculaJuros.Domain.Service.Services
{
    public class TaxaJurosApiService : ITaxaJurosApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ICalculaJurosConfiguration _config;

        public TaxaJurosApiService(IHttpClientFactory clientFactory, ICalculaJurosConfiguration config)
        {
            _clientFactory = clientFactory;
            _config = config;
        }

        public async Task<double> GetTaxaJurosAsync()
        {
            var client = _clientFactory.CreateClient();

            var result = await client.GetAsync(_config.TaxaJurosApiUrl);

            if (result.IsSuccessStatusCode)
            {
                return Convert.ToDouble(await result.Content.ReadAsStringAsync(), CultureInfo.GetCultureInfo(_config.Culture).NumberFormat);
            }

            throw new HttpRequestException(result.StatusCode.ToString());
        }
    }
}
