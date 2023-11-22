using ExchangeRatesAPI.DTO;
using ExchangeRatesAPI.Models;

namespace ExchangeRatesAPI.Interfaces
{
    public interface IPartnerRates
    {
        public List<ExchangeRate> GetExchangeRates();
    }
}
