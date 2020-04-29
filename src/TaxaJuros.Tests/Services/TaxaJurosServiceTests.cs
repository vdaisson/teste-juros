using FluentAssertions;
using NSubstitute;
using TaxaJuros.Domain.Interfaces.Repositories;
using TaxaJuros.Domain.Service.Services;
using Xunit;

namespace TaxaJuros.Test.Services
{
    public class TaxaJurosServiceTests
    {
        private readonly ITaxaJurosRepository _repository;
        private readonly TaxaJurosService _service;

        public TaxaJurosServiceTests()
        {
            _repository = Substitute.For<ITaxaJurosRepository>();
            _service = new TaxaJurosService(_repository);
        }

        [Fact]
        public void Quando_chamado_get_retorna_valor_fixo()
        {
            _repository.Get().Returns(0.01);

            var result = _service.Get();

            result.Should().Be(0.01);
        }
    }
}
