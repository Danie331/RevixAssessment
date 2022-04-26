using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class CurrencyQuote
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public int QuoteProviderId { get; set; }
        public decimal Price { get; set; }
        public DateTime RecordUpdatedDate { get; set; }
        public DateTime? ProviderLastUpdatedDate { get; set; }
    }
}
