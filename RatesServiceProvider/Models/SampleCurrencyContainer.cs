using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExternalServiceProviders.Models
{
    internal class SampleCurrencyContainer
    {
        [JsonProperty("data")]
        public IEnumerable<Currency> Data { get; set; }
    }
}
