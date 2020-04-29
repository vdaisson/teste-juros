using TaxaJuros.Domain.Interfaces.Configurations;

namespace TaxaJuros.Domain.Configurations
{
    public class TaxaJurosConfiguration : ITaxaJurosConfiguration
    {
        public string Culture { get; set; }
    }
}
