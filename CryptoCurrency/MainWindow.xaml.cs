using CryptoCurrency.Interfaces;
using CryptoCurrency.Models;
using CryptoCurrency.Models.Responses;
using CryptoCurrency.Pages;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace CryptoCurrency
{
    public partial class MainWindow : Window
    {
        private readonly IApiClient _coinCapApi;

        public MainWindow(IApiClient coinCapApi)
        {
            InitializeComponent();

            _coinCapApi = coinCapApi;

            Loaded += Window_Loaded;            
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        { 
            IEnumerable<Asset> items = await _coinCapApi.GetAssetsAsync();

            ObservableCollection<Currency> currencies = new();
            foreach (Asset item in items.ToList().Take(10))
            {
                Currency currency = new()
                {
                    Name = item.Name ?? default,
                    Symbol = item.Symbol ?? default,
                    Price = item.PriceUsd ?? default ,
                    PriceChange = item.ChangePercent24Hr ?? default ,
                    Volume = item.VolumeUsd24hr ?? default,
                    Url = item.Explorer ?? default
                };

                currencies.Add(currency);
            }

            DataContext = new CurrencyViewModel(currencies);
        }

        private void Btn_Info_Click(object sender, RoutedEventArgs e) 
        {
            Main.Content = new Info(DataContext);
        }

        private void Btn_Chart_Click(object sender, RoutedEventArgs e) 
        {
            Main.Content = new Chart(DataContext);
        }

        private void Btn_Converter_Click(object sender, RoutedEventArgs e) 
        {
            Main.Content = new Converter(_coinCapApi);
        }

        private void Btn_Top_Click(object sender, RoutedEventArgs e) 
        {
            Main.Content = new Top(DataContext);
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Search(_coinCapApi);
        }
    }
}

