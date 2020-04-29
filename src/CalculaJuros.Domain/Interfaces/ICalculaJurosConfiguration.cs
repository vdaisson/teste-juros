namespace CalculaJuros.Domain.Interfaces
{
    public interface ICalculaJurosConfiguration
    {
        string Culture { get; set; }
        string TaxaJurosApiUrl { get; set; }
        string ShowMeTheCodeUrl { get; set; }
    }
}
