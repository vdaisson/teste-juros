using System.Threading.Tasks;

namespace CalculaJuros.Domain.Service.Interfaces
{
    public interface ICalculaJurosService
    {
        Task<decimal> CalculaAsync(double valorInicial, int meses);
    }
}
