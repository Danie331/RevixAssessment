
namespace DomainModels
{
    public class CurrencyPair
    {
        public CurrencyDefinition BaseCurrency { get; set; }
        public CurrencyDefinition QuotedCurrency { get; set; }
        public decimal Price { get; set; }
    }
}
