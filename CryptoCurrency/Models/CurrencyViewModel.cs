using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrency.Models
{
    public class CurrencyViewModel : INotifyPropertyChanged
    {
        private Currency selectedCurrency;

        public ObservableCollection<Currency> Currencies { get; set; }
        public Currency SelectedCurrency
        {
            get { return selectedCurrency; }
            set
            {
                selectedCurrency = value;
                OnPropertyChanged("SelectedCurrency");
            }
        }

        public CurrencyViewModel(ObservableCollection<Currency> currencies)
        {
            Currencies = currencies ?? new ObservableCollection<Currency>();  
        }

        public CurrencyViewModel()
        {
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
