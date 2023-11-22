namespace ExchangeRatesAPI.Models
{
    public class ExchangeRate
    {
        public String Currency { get; set; }
        public String PaymentMethod { get; set; }
        public String DeliveryMethod { get; set; }
        public decimal Rate { get; set; } //decimal is often used for money (also noticed the 'm' in the pdf rates), OR float for potential less bytes
        public DateTime AcquiredDate { get; set; }



        //"Currency": "MXN",
        //"PaymentMethod": "debit",
        //"DeliveryMethod": "cash",
        //"Rate": 16.78,
        //"AcquiredDate": "2023-07-24T05:00:00.000Z"
    }
}
