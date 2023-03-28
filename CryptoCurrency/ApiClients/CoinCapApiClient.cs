using CryptoCurrency.Interfaces;
using CryptoCurrency.Models.Responses;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Serilog;

namespace CryptoCurrency.ApiClients
{
    public class CoinCapApiClient : IApiClient
    {
        private const string ClassName = nameof(CoinCapApiClient);

        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly ILogger _logger;

        public CoinCapApiClient(IConfiguration configuration, IHttpClientFactory httpClientFactory, ILogger logger)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;

            _logger = logger;
        }

        public Task<IEnumerable<AssetHistory>> GetAssetHistory()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Asset>> GetAssetsAsync(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                return Enumerable.Empty<Asset>();
            }

            const string methodName = nameof(GetAssetsAsync);

            HttpResponseMessage? httpResponseMessage;
            try
            {
                httpResponseMessage = await _httpClientFactory.CreateClient().GetAsync(_configuration["ApiUrls:Assets"] + $"/{id}");
            }
            catch (Exception ex)
            {
                _logger.Error("{msg}", ex);
                return Enumerable.Empty<Asset>();
            }

            if (httpResponseMessage is null)
            {
                _logger.Error("{class} {method} {msg}", ClassName, methodName, "httpResponseMessage is null");
                return Enumerable.Empty<Asset>();
            }

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                _logger.Error("{class} {method} {msg}", ClassName, methodName, $"StatusCode: {httpResponseMessage.StatusCode} !httpResponseMessage.IsSuccessStatusCode");
                return Enumerable.Empty<Asset>();
            }

            string response;
            try
            {
                response = await httpResponseMessage.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                _logger.Error("{msg}", ex);
                return Enumerable.Empty<Asset>();
            }

            if (string.IsNullOrWhiteSpace(response))
            {
                _logger.Error("{class} {method} {msg}", ClassName, methodName, "string.IsNullOrWhiteSpace(response)");
                return Enumerable.Empty<Asset>();
            }

            AssetData? assetData;
            try
            {
                assetData = JsonSerializer.Deserialize<AssetData>(response);
            }
            catch (Exception ex)
            {
                _logger.Error("{msg}", ex);
                return Enumerable.Empty<Asset>();
            }

            List<Asset> assetList = new List<Asset>();
            assetList.Add(assetData?.Data);
            return assetList ?? Enumerable.Empty<Asset>();
        }

        public async Task<IEnumerable<Asset>> GetAssetsAsync()
        {
            const string methodName = nameof(GetAssetsAsync);

            HttpResponseMessage? httpResponseMessage;
            try
            {
                httpResponseMessage = await _httpClientFactory.CreateClient().GetAsync(_configuration["ApiUrls:Assets"]);
            }
            catch (Exception ex)
            {
                _logger.Error("{msg}", ex);
                return Enumerable.Empty<Asset>();
            }

            if (httpResponseMessage is null)
            {
                _logger.Error("{class} {method} {msg}", ClassName, methodName, "httpResponseMessage is null");
                return Enumerable.Empty<Asset>();
            }

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                _logger.Error("{class} {method} {msg}", ClassName, methodName, $"StatusCode: {httpResponseMessage.StatusCode} !httpResponseMessage.IsSuccessStatusCode");
                return Enumerable.Empty<Asset>();
            }

            string response;
            try
            {
                response = await httpResponseMessage.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                _logger.Error("{msg}", ex);
                return Enumerable.Empty<Asset>();
            }

            if (string.IsNullOrWhiteSpace(response))
            {
                _logger.Error("{class} {method} {msg}", ClassName, methodName, "string.IsNullOrWhiteSpace(response)");
                return Enumerable.Empty<Asset>();
            }

            AssetList? asset;
            try
            {
                asset = JsonSerializer.Deserialize<AssetList>(response);
            }
            catch (Exception ex)
            {
                _logger.Error("{msg}", ex);
                return Enumerable.Empty<Asset>();
            }         

            return asset?.Data ?? Enumerable.Empty<Asset>();
        }

        public Task<IEnumerable<Candle>> GetCandles()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Exchange>> GetExchanges()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Market>> GetMarkets()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Rate>> GetRates()
        {
            throw new NotImplementedException();
        }
    }
}
