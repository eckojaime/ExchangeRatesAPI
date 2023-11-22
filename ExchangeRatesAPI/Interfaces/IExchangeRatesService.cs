using ExchangeRatesAPI.DTO;

namespace ExchangeRatesAPI.Interfaces
{
    public interface IExchangeRatesService
    {
        public List<ExchangeRateDTO> GetExchangeRates(String country);
    }
}
