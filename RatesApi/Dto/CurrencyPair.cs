
namespace RatesApi.Dto
{
    public class CurrencyPair
    {
        public int BaseCurrencyId { get; set; }
        public string BaseCurrencyName { get; set; }
        public string BaseCurrencySymbol { get; set; }
        public int QuotedCurrencyId { get; set; }
        public string QuotedCurrencyName { get; set; }
        public string QuotedCurrencySymbol { get; set; }
        public decimal Price { get; set; }
    }
}
