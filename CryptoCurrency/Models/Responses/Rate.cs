using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrency.Models.Responses
{
    public class Rate
    {
        public string? id { get; set; }
        public string? symbol { get; set; }   
        public string? currencySymbol { get; set; }
        public string? type { get; set; }   
        public string? rateUsd { get; set; }
    }
}
