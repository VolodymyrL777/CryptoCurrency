using CryptoCurrency.Interfaces;
using CryptoCurrency.Models.Responses;
using System;
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
        private const string Url = "https://api.coincap.io/v2/";

        public Task<IEnumerable<AssetHistory>> GetAssetHistory()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Asset> GetAssets()
        {
            AssetList assets = new AssetList();
            string responseBody = String.Empty;
            
            try
            {
                var response = client.GetAsync(Url + "assets").Result; 
                response.EnsureSuccessStatusCode();
                responseBody = response.Content.ReadAsStringAsync().Result;                
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            try
            {
                assets = JsonSerializer.Deserialize<AssetList>(responseBody) ?? new AssetList();
            }
            catch (SerializationException ex)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", ex.Message);
            }
            return assets.data ?? new List<Asset>();
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
