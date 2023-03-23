using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrency.Models.Responses
{
    public class AssetHistory
    {
        public string? priceUsd { get; set; }
        public long time { get; set; }   
    }
}
