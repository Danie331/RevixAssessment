using AutoMapper;
using DomainModels;
using Newtonsoft.Json;
using ExternalServiceProviders.Configuration.Contract;
using ExternalServiceProviders.Contract;
using ExternalServiceProviders.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace ExternalServiceProviders.Core
{
    public class CoinMarketCapServiceProvider : IRatesServiceProvider
    {
        private readonly IMapper _mapper;
        private readonly IRatesServiceConfigurationProvider _configurationProvider;
        private readonly HttpClient _httpClient;
        public CoinMarketCapServiceProvider(IMapper mapper, IRatesServiceConfigurationProvider configurationProvider, HttpClient httpClient)
        {
            _mapper = mapper;
            _configurationProvider = configurationProvider;
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri(_configurationProvider.BaseAddress);
            _httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", _configurationProvider.ApiKey);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            // (de)compression can be added later
            //_httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "deflate, gzip");
        }

        public async Task<IEnumerable<CurrencyDefinition>> GetCurrenciesAsync()
        {
            try
            {
                var requestUri = "/v1/cryptocurrency/map";
                var result = await _httpClient.GetStringAsync(requestUri);
                var responseData = JsonConvert.DeserializeObject<SampleCurrencyContainer>(result);

                return _mapper.Map<IEnumerable<CurrencyDefinition>>(responseData.Data);
            }
            catch (Exception ex)
            {
                // Log error first
                throw;
            }
        }

        public async Task<IEnumerable<CurrencyPair>> GetLatestMarketQuotesAsync()
        {
            try
            {
                var requestUri = "/v1/cryptocurrency/listings/latest";
                var result = await _httpClient.GetStringAsync(requestUri);
                var responseContainer = JsonConvert.DeserializeObject<SampleCurrencyContainer>(result);
                JObject container = JObject.Parse(result);
                foreach (var currency in responseContainer.Data)
                {
                    var target = container.Descendants()
                             .Where(t => t.Type == JTokenType.Property && ((JProperty)t).Name == "symbol")
                             .Select(p => ((JProperty)p))
                             .First(p => p.Value.Value<string>().Equals(currency.Symbol));

                    var quotes = target.Parent.Where(t => t.Type == JTokenType.Property && ((JProperty)t).Name == "quote");
                }

                return null;
            }
            catch(Exception ex)
            {
                // Log error first
                throw;
            }
        }

        public async Task<IEnumerable<CurrencyPair>> GetLatestMarketQuotesAsync(int providerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CurrencyPair>> GetLatestMarketQuotesAsync(string symbol)
        {
            throw new NotImplementedException();
        }
    }
}
