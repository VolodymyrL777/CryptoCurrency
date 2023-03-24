using CryptoCurrency.ApiClients;
using CryptoCurrency.Models;
using CryptoCurrency.Models.Responses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptoCurrency
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ObservableCollection<Currency> currencies = new ObservableCollection<Currency>();

            CoinCapApiClient coinCap = new CoinCapApiClient();
            var data = coinCap.GetAssets();            
            foreach (var item in data)
            {
                Currency currency = new Currency {
                    Name = item.name,
                    Symbol = item.symbol,
                    Price = item.priceUsd,
                    PriceChange = item.changePercent24Hr,
                    Volume = item.volumeUsd24hr
                };
                currencies.Add(currency);
            }            
            
            DataContext = new CurrencyViewModel(currencies); 
        }
    }
}
