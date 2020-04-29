using System.Threading.Tasks;

namespace CalculaJuros.Domain.Service.Interfaces
{
    public interface ITaxaJurosApiService
    {
        Task<double> GetTaxaJurosAsync();
    }
}
