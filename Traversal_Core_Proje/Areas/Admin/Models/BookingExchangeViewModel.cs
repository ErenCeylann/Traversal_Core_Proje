namespace Traversal_Core_Proje.Areas.Admin.Models
{
    public class BookingExchangeViewModel
    {

        public string base_currency_date { get; set; }
        public Exchange_Rates[] exchange_rates { get; set; }

        public class Exchange_Rates
        {
            public int exchange_rate_buy { get; set; }
            public string currency { get; set; }
        }

        
    }
}
