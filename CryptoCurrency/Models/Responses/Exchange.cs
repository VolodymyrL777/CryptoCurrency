namespace CryptoCurrency.Models.Responses
{
    public class Exchange
    {
        public string? id { get; set; }
        public string? name { get; set; }   
        public string? rank { get; set; }
        public string? percentTotalVolume { get; set; }   
        public string? volumeUsd { get; set; }
        public string? tradingPairs { get; set; }   
        public bool socket { get; set; }
        public string? exchangeUrl { get; set; }   
        public long updated { get; set; }
    }
}
