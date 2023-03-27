using CryptoCurrency.Interfaces;
using CryptoCurrency.Models.Responses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace CryptoCurrency.ApiClients
{
    public class CoinCapApiClient : IApiClient
    {
        static readonly HttpClient client = new HttpClient();
        private const string ApiUrl = "https://api.coincap.io/v2";

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

            HttpResponseMessage? httpResponseMessage;
            try
            {
                httpResponseMessage = await client.GetAsync($"{ApiUrl}/assets/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now}] {ex}");
                return Enumerable.Empty<Asset>();
            }

            if (httpResponseMessage is null)
            {
                return Enumerable.Empty<Asset>();
            }

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                return Enumerable.Empty<Asset>();
            }

            string response;
            try
            {
                response = await httpResponseMessage.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now}] {ex}");
                return Enumerable.Empty<Asset>();
            }

            if (string.IsNullOrWhiteSpace(response))
            {
                return Enumerable.Empty<Asset>();
            }

            AssetData? assetData;
            try
            {
                assetData = JsonSerializer.Deserialize<AssetData>(response);
            }
            catch (Exception ex)
            {                
                Console.WriteLine($"[{DateTime.Now}] {ex}");
                return Enumerable.Empty<Asset>();
            }

            List<Asset> assetList = new List<Asset>();
            assetList.Add(assetData?.Data);
            return assetList ?? Enumerable.Empty<Asset>();
        }

        public async Task<IEnumerable<Asset>> GetAssetsAsync()
        {
            HttpResponseMessage? httpResponseMessage;
            try
            {
                httpResponseMessage = await client.GetAsync($"{ApiUrl}/assets");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now}] {ex}");
                return Enumerable.Empty<Asset>();
            }

            if (httpResponseMessage is null)
            {
                return Enumerable.Empty<Asset>();
            }

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                return Enumerable.Empty<Asset>();
            }

            string response;
            try
            {
                response = await httpResponseMessage.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now}] {ex}");
                return Enumerable.Empty<Asset>();
            }

            if (string.IsNullOrWhiteSpace(response))
            {
                return Enumerable.Empty<Asset>();
            }

            AssetList? assets;
            try
            {
                assets = JsonSerializer.Deserialize<AssetList>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now}] {ex}");
                return Enumerable.Empty<Asset>();
            }

            return assets?.Data ?? Enumerable.Empty<Asset>();
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
