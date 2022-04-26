
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExternalServiceProviders.Models
{
    internal class Currency
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        public IEnumerable<Currency> Quotes { get; set; }
    }
}
