using System;
using Xunit;
using FluentAssertions;

namespace CalculaJuros.Test
{
    public class CalculaJurosDomainTest
    {
        private readonly Domain.CalculaJuros _entity;

        public CalculaJurosDomainTest()
        {
            _entity = new Domain.CalculaJuros();
        }

        [Fact]
        public void Quando_valor_inicial_invalido_retorna_argument_excepton_relativo_a_valor_inicial()
        {
            var valorInicial = -100d;
            var juros = 0.01;
            var meses = 10;

            Action act = () => _entity.Calcula(valorInicial, juros, meses);

            act.Should().Throw<ArgumentOutOfRangeException>().And.ParamName.Should().Be("valorInicial");
        }

        [Fact]
        public void Quando_valor_de_meses_invalido_retorna_argument_excepton_relativo_a_meses()
        {
            var valorInicial = 100d;
            var juros = 0.01;
            var meses = -1;

            Action act = () => _entity.Calcula(valorInicial, juros, meses);

            act.Should().Throw<ArgumentOutOfRangeException>().And.ParamName.Should().Be("meses");
        }

        [Fact]
        public void Quando_valor_de_juros_invalido_retorna_argument_excepton_relativo_a_juros()
        {
            var valorInicial = 100d;
            var juros = -0.01;
            var meses = 10;

            Action act = () => _entity.Calcula(valorInicial, juros, meses);

            act.Should().Throw<ArgumentOutOfRangeException>().And.ParamName.Should().Be("taxaJuros");
        }

        [Fact]
        public void Quando_valores_validos_calcular_corretamente_valores_pequenos()
        {
            var valorInicial = 100d;
            var juros = 0.01;
            var meses = 10;

            var result = _entity.Calcula(valorInicial, juros, meses);

            result.Should().Be(110.46m);
        }

        [Fact]
        public void Quando_valores_validos_calcular_corretamente_valores_medios()
        {
            var valorInicial = 7549d;
            var juros = 0.05;
            var meses = 24;

            var result = _entity.Calcula(valorInicial, juros, meses);

            result.Should().Be(24346.27m);
        }

        [Fact]
        public void Quando_valores_validos_calcular_corretamente_valores_grandes()
        {
            var valorInicial = 89666273d;
            var juros = 0.15;
            var meses = 72;

            var result = _entity.Calcula(valorInicial, juros, meses);

            result.Should().Be(2103166347393.26m);
        }
    }
}
