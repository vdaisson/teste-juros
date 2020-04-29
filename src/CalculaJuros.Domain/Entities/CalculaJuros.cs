using CalculaJuros.Domain.Interfaces;
using System;
using CalculaJuros.Domain.Extensions;

namespace CalculaJuros.Domain
{
    public class CalculaJuros : ICalculaJuros
    {
        private const int NUMERO_DE_CASAS_DECIMAIS = 2;

        public decimal Calcula(double valorInicial, double taxaJuros, int meses)
        {
            VerificarValoresInvalidos(valorInicial, taxaJuros, meses);

            decimal result = Convert.ToDecimal(valorInicial * Math.Pow(1 + taxaJuros, meses));

            return result.TruncateDecimal(2);
        }

        private void VerificarValoresInvalidos(double valorInicial, double taxaJuros, int meses)
        {
            if (valorInicial < 0)
            {
                throw new ArgumentOutOfRangeException("valorInicial");
            }

            if (taxaJuros < 0)
            {
                throw new ArgumentOutOfRangeException("taxaJuros");
            }

            if (meses < 0)
            {
                throw new ArgumentOutOfRangeException("meses");
            }
        }
    }
}
