using ExchangeRatesAPI.Interfaces;
using ExchangeRatesAPI.Models;
using Newtonsoft.Json;


namespace ExchangeRatesAPI.PartnerRates
{
    public class JsonFilePartnerRates : IPartnerRates
    {
        //read file and try/catch
        //convert into objects
        public List<ExchangeRate> GetExchangeRates()
        {
            List<ExchangeRate> exchangeRates = new List<ExchangeRate>();
            try
            {
                String jsonFilePath = Path.Combine(Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory), "JsonFilePartnerRates.json");
                using (StreamReader reader = new StreamReader(jsonFilePath))
                {
                    string json = reader.ReadToEnd();
                    Models.PartnerRatesModel partnerRates = JsonConvert.DeserializeObject<Models.PartnerRatesModel>(json);
                    exchangeRates = partnerRates.PartnerRates;
                }

                return exchangeRates;
            }
            catch (Exception ex) 
            {
                //log if error
                System.Console.WriteLine(ex.Message);
            }

            return exchangeRates;
        }
    }
}
