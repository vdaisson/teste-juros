using CalculaJuros.Domain.Interfaces;
using CalculaJuros.Domain.Service.Interfaces;
using System.Threading.Tasks;

namespace CalculaJuros.Domain.Service.Services
{
    public class CalculaJurosService : ICalculaJurosService
    {
        private readonly ICalculaJuros _domain;
        private readonly ITaxaJurosApiService _taxaJurosApiService;

        public CalculaJurosService(ICalculaJuros domain, ITaxaJurosApiService taxaJurosApiService)
        {
            _domain = domain;
            _taxaJurosApiService = taxaJurosApiService;
        }

        public async Task<decimal> CalculaAsync(double valorInicial, int meses)
        {
            var taxaJuros = await _taxaJurosApiService.GetTaxaJurosAsync();

            return _domain.Calcula(valorInicial, taxaJuros, meses);
        }
    }
}
