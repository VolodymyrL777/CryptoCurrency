using CryptoCurrency.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoCurrency.Interfaces
{
    public interface IApiClient
    {
        Task <IEnumerable<Asset>> GetAssetsAsync();
        Task <IEnumerable<Asset>> GetAssetsAsync(string id);
        Task <IEnumerable<AssetHistory>> GetAssetHistory();
        Task <IEnumerable<Candle>> GetCandles();
        Task <IEnumerable<Exchange>> GetExchanges();
        Task <IEnumerable<Market>> GetMarkets();
        Task <IEnumerable<Rate>> GetRates();   
        
    }
}
