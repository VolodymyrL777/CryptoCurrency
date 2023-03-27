using CryptoCurrency.ApiClients;
using CryptoCurrency.Models;
using CryptoCurrency.Models.Responses;
using CryptoCurrency.Pages;
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
            Loaded += Window_Loaded;            
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CoinCapApiClient coinCap = new();

            IEnumerable<Asset> items = await coinCap.GetAssetsAsync();

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
            Main.Content = new Converter();
        }

        private void Btn_Top_Click(object sender, RoutedEventArgs e) 
        {
            Main.Content = new Top(DataContext);
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Search();
        }
    }
}

