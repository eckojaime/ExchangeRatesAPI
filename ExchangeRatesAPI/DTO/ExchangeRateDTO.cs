namespace ExchangeRatesAPI.DTO
{
    public class ExchangeRateDTO
    {
        public String CurrencyCode { get; set; }
        public String CountryCode { get; set; }
        public decimal PangeaRate { get; set; } //decimal is often used for money (also noticed the 'm' in the pdf rates), OR float for potential less bytes
        public String PaymentMethod { get; set; }
        public String DeliveryMethod { get; set; }


//"CurrencyCode":"MXN",
//"CountryCode":"MEX",
//"PangeaRate": 17.24,
//"PaymentMethod": "debit",
//"DeliveryMethod": "cash"

    }
}
