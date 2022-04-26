using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RatesService.Contract;
using System.Threading.Tasks;

namespace RatesApi.Controllers.V1
{
    [Route("api/v1/rates"),  ApiController]
    public class RatesController : BaseController
    {
        private readonly IRatesService _ratesService;

        public RatesController(IRatesService ratesService, IMapper mapper) : base(mapper)
        {
            _ratesService = ratesService;
        }

        [HttpGet("mappings")]
        public async Task<IActionResult> GetCurrencyMappings()
        {
            var currencies = await _ratesService.GetCurrenciesAsync();
            return Ok(ToDtoList<Dto.Currency, DomainModels.CurrencyDefinition>(currencies));
        }

        [HttpGet("latestquotes")]
        public async Task<IActionResult> GetLatestMarketQuotes()
        {
            var rates = await _ratesService.GetMarketRatesAsync();
            return Ok(ToDtoList<Dto.CurrencyPair, DomainModels.CurrencyPair>(rates));
        }
    }
}
