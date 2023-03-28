using CryptoCurrency.Models.Responses;
using CryptoCurrency.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using CryptoCurrency.Interfaces;

namespace CryptoCurrency.Pages
{
    public partial class Search : Page
    {
        private readonly IApiClient _coinCapApi;

        public Search(IApiClient coinCapApi)
        {
            InitializeComponent();

            _coinCapApi = coinCapApi;
            DataContext = null;
        }

        private async void Search_Click(object sender, RoutedEventArgs e)
        { 
            IEnumerable<Asset> items = await _coinCapApi.GetAssetsAsync(currency_id.Text);

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
