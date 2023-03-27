using CryptoCurrency.ApiClients;
using CryptoCurrency.Models.Responses;
using CryptoCurrency.Models;
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

namespace CryptoCurrency.Pages
{
    /// <summary>
    /// Логика взаимодействия для Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        public Search()
        {
            InitializeComponent();
        }

        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            CoinCapApiClient coinCap = new();

            IEnumerable<Asset> items = await coinCap.GetAssetsAsync(currency_id.Text);

            ObservableCollection<Currency> currencies = new();
            foreach (Asset item in items)
            {
                Currency currency = new()
                {
                    Name = item.Name ?? default,
                    Symbol = item.Symbol ?? default,
                    Price = item.PriceUsd ?? default,
                    PriceChange = item.ChangePercent24Hr ?? default,
                    Volume = item.VolumeUsd24hr ?? default,
                    Url = item.Explorer ?? default
                };

                currencies.Add(currency);
            }

            DataContext = new CurrencyViewModel(currencies);
        }
    }
}
