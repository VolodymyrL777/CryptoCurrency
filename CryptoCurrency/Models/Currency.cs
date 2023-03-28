using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CryptoCurrency.Models
{
    public class Currency : INotifyPropertyChanged
    {
        private string? name;
        private string? url;   
        private string? symbol;   
        private string? price;
        private string? volume;
        private string? priceChange;
        private List<MarketPlace>? markets;

        public string? Url
        {
            get { return url; }
            set
            {
                url = value;
                OnPropertyChanged("Name");
            }
        }

        public string? Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string? Symbol
        {
            get { return symbol; }
            set
            {
                symbol = value;
                OnPropertyChanged("Symbol");
            }
        }

        public string? Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public string? Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                OnPropertyChanged("Volume");
            }
        }

        public string? PriceChange
        {
            get { return priceChange; }
            set
            {
                priceChange = value;
                OnPropertyChanged("PriceChange");
            }
        }

        public List<MarketPlace>? Markets
        {
            get { return markets; }
            set
            {
                markets = value;
                OnPropertyChanged("Markets");
            }
        }        

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
