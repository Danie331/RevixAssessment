using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public DateTime RecordUpdatedDate { get; set; }
        public DateTime? ProviderLastUpdatedDate { get; set; }
    }
}
