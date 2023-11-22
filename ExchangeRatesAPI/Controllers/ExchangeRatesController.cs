using ExchangeRatesAPI.DTO;
using ExchangeRatesAPI.Interfaces;
using ExchangeRatesAPI.PartnerRates;
using ExchangeRatesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRatesAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly ILogger<ExchangeRatesController> _logger;
        private readonly IExchangeRatesService _exchangeRatesService;

        public ExchangeRatesController(ILogger<ExchangeRatesController> logger)
        {
            _logger = logger;
            _exchangeRatesService = new ExchangeRatesService(new JsonFilePartnerRates()); //instantiate with JsonFilePartnerRates implementation
        }

        [HttpGet("exchange-rates")]
        public IEnumerable<ExchangeRateDTO> GetExchangeRates(String country)
        {
            List<ExchangeRateDTO> exchangeRatesDTO = _exchangeRatesService.GetExchangeRates(country);

            return exchangeRatesDTO;
        }
    }
}
