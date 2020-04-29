using Xunit;
using FluentAssertions;
using TaxaJuros.Domain.Interfaces.Repositories;
using TaxaJuros.Infrastructure.Data.Repositories.TaxaJuros;

namespace TaxaJuros.Test.Repositories.TaxaJuros
{
    public class TaxaJurosRepositoryTests
    {
        private readonly ITaxaJurosRepository _repository;

        public TaxaJurosRepositoryTests()
        {
            _repository = new TaxaJurosRepository();
        }

        [Fact]
        public void Quando_chamado_get_retorna_valor_fixo()
        {
            var result = _repository.Get();

            result.Should().Be(0.01);
        }
    }
}
