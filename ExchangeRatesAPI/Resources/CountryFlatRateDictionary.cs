namespace ExchangeRatesAPI.Resources
{
    public class CountryFlatRateDictionary
    {
        public static Dictionary<String, decimal> FlatRateMapping = new Dictionary<String, decimal>()
        {
            { "MEX", 0.024m },
            { "PHL", 2.437m },
            { "GTM", 0.056m },
            { "IND", 3.213m }
        };

//  Mexico = 0.024m
//● Philippines = 2.437m
//● Guatemala = 0.056m
//● India = 3.213m
    }
}
