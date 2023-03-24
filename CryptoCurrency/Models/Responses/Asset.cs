﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrency.Models.Responses
{
    public class AssetList 
    {
        public List<Asset>? data { get; set; } 
    }

    public class Asset
    {
        public string? id { get; set; }
        public string? rank { get; set; } 
        public string? symbol { get; set; }   
        public string? name { get; set; }
        public string? supply { get; set; } 
        public string? maxSupply { get; set; }   
        public string? marketCapUsd { get; set; }
        public string? volumeUsd24hr { get; set; } 
        public string? priceUsd { get; set; }   
        public string? changePercent24Hr { get; set; }
        public string? vwap24Hr { get; set; }
    }
}
