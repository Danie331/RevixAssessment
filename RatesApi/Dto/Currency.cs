
using Newtonsoft.Json;

namespace RatesApi.Dto
{
    public class Currency
    {
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string ProviderSymbol { get; set; }
    }
}
