namespace CalculaJuros.Domain.Interfaces
{
    public interface ICalculaJuros
    {
        decimal Calcula(double valorInicial, double taxaJuros, int meses);
    }
}
