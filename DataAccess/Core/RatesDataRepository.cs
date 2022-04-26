using AutoMapper;
using DataAccess.Contract;
using DataAccess.Entities;
using DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Core
{
    public class RatesDataRepository : IRatesDataRepository
    {
        private readonly IMapper _mapper;
        private readonly MarketRatesContext _context;
        public RatesDataRepository(MarketRatesContext context,
                             IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddCurrenciesAsync(IEnumerable<CurrencyDefinition> items)
        {
            try
            {
                foreach (var item in items)
                {
                    var targetRecord = await _context.Currency.FirstOrDefaultAsync(x => x.ProviderId == item.Id);
                    if (targetRecord == null)
                    {
                        // insert
                        var newRecord = _mapper.Map<Currency>(item);
                        newRecord.ProviderLastUpdatedDate = null;
                        newRecord.RecordUpdatedDate = DateTime.Now;
                        await _context.Currency.AddAsync(newRecord);
                    }
                    else
                    {
                        // update
                        var entity = _mapper.Map(item, targetRecord, typeof(CurrencyDefinition), typeof(Currency));
                        _context.Entry(entity).State = EntityState.Modified;
                    }

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log ex
                throw;
            }
        }
    }
}
