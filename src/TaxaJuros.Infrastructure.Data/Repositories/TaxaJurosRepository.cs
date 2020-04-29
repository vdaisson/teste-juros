using TaxaJuros.Domain.Interfaces.Repositories;

namespace TaxaJuros.Infrastructure.Data.Repositories.TaxaJuros
{
    public class TaxaJurosRepository : ITaxaJurosRepository
    {
        public double Get()
        {
            return 0.01;
        }
    }
}
