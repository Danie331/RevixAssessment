

using DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Contract
{
    public interface IRatesDataRepository
    {
        Task AddCurrenciesAsync(IEnumerable<CurrencyDefinition> items);
    }
}
