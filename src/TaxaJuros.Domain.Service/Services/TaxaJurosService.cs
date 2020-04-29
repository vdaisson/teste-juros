using TaxaJuros.Domain.Interfaces.Repositories;
using TaxaJuros.Domain.Service.Interfaces;

namespace TaxaJuros.Domain.Service.Services
{
    public class TaxaJurosService : ITaxaJurosService
    {
        private readonly ITaxaJurosRepository _repository;

        public TaxaJurosService(ITaxaJurosRepository repository)
        {
            _repository = repository;
        }

        public double Get()
        {
            return _repository.Get();
        }
    }
}
