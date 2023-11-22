using ExchangeRatesAPI.DTO;
using ExchangeRatesAPI.Interfaces;
using ExchangeRatesAPI.Models;
using ExchangeRatesAPI.Resources;

namespace ExchangeRatesAPI.Services
{
    public class ExchangeRatesService : IExchangeRatesService
    {
        private readonly IPartnerRates _partnerRates;
        public ExchangeRatesService(IPartnerRates partnerRates) { _partnerRates = partnerRates; }

        /// <summary>
        /// Business logic
        /// </summary>
        public List<ExchangeRateDTO> GetExchangeRates(String country)
        {
            String mappedCurrency = CountryDictionary.CurrencyMapping.GetValueOrDefault(country);
            List<ExchangeRate> exchangeRates = filterExchangeRates(_partnerRates.GetExchangeRates(), mappedCurrency);
            List<ExchangeRateDTO> exchangeRateDTOs = new List<ExchangeRateDTO>();

            if (exchangeRates != null || exchangeRates.Count > 0) 
            {
                
                decimal mappedFlatRate = CountryFlatRateDictionary.FlatRateMapping.GetValueOrDefault(country);

                #region Original way
                //foreach (var exchangeRate in exchangeRates) 
                //{                    
                //    if (String.Equals(mappedCurrency, exchangeRate.Currency)) 
                //    {
                //        ExchangeRateDTO exchangeRateDTO = new ExchangeRateDTO()
                //        {
                //            CountryCode = country, //country should be the same anyway, so no need to reverse map
                //            CurrencyCode = exchangeRate.Currency,
                //            PangeaRate = ConvertToPangeaRate(exchangeRate.Rate, mappedFlatRate),
                //            DeliveryMethod = exchangeRate.DeliveryMethod,
                //            PaymentMethod = exchangeRate.PaymentMethod
                //        };

                //        exchangeRateDTOs.Add(exchangeRateDTO);
                //    }

                //}
                #endregion

                //Changed to Lambda
                exchangeRateDTOs = exchangeRates.
                    Select(x => new ExchangeRateDTO
                    {
                        CountryCode = country, //country should be the same anyway, so no need to reverse map
                        CurrencyCode = x.Currency,
                        PangeaRate = ConvertToPangeaRate(x.Rate, mappedFlatRate),
                        DeliveryMethod = x.DeliveryMethod,
                        PaymentMethod = x.PaymentMethod
                    }).ToList();

            }
            return exchangeRateDTOs;
        }

        private List<ExchangeRate> filterExchangeRates(List<ExchangeRate> rates, String currency) 
        {
            if (rates != null || rates.Count > 0)
            {
                Dictionary<String, ExchangeRate> filteredDictionary = new Dictionary<String, ExchangeRate>();

                foreach (var rate in rates)
                {
                    if (String.Equals(rate.Currency, currency)) //Filter by desired country/currency
                    {
                        String key = rate.PaymentMethod + rate.DeliveryMethod; //What defines a specific rate
                        if (filteredDictionary.ContainsKey(key))
                        {
                            ExchangeRate filteredExchangeRate = filteredDictionary[key];
                            if (filteredExchangeRate.AcquiredDate < rate.AcquiredDate)
                            {
                                filteredDictionary[key] = rate;
                            }
                        }
                        else
                        {
                            filteredDictionary.Add(key, rate);
                        }
                    }
                    
                }

                return filteredDictionary.Values.ToList();
            }
            else
            {
                return null;
            }
        }

        private decimal ConvertToPangeaRate(decimal partnerExchangeRate, decimal countryFlatRate) 
        {
            decimal pangeaExchangeRate = Decimal.Round(partnerExchangeRate + countryFlatRate, 2);
            return pangeaExchangeRate;
        }
    }
}
