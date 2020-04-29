using CalculaJuros.Domain.Interfaces;

namespace CalculaJuros.Domain.Configurations
{
    public class CalculaJurosConfiguration : ICalculaJurosConfiguration
    {
        public string Culture { get; set; }
        public string TaxaJurosApiUrl { get; set; }
        public string ShowMeTheCodeUrl { get; set; }
    }
}
