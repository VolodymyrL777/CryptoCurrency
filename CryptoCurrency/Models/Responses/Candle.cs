using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrency.Models.Responses
{
    public class Candle
    {
        public string? open { get; set; }
        public string? high { get; set; }
        public string? low { get; set; }
        public string? close { get; set; }
        public string? volume { get; set; }
        public long period { get; set; }
    }
}
