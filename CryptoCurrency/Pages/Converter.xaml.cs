using CryptoCurrency.Models.Responses;
using CryptoCurrency.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using CryptoCurrency.Interfaces;

namespace CryptoCurrency.Pages
{
    public partial class Converter : Page
    {
        private readonly IApiClient _coinCapApi;

        public Converter(IApiClient coinCapApi)
        {
            InitializeComponent();

            _coinCapApi = coinCapApi;

            Loaded += Converter_Loaded;
        }

        private async void Converter_Loaded(object sender, RoutedEventArgs e)
        {
            IEnumerable<Asset> items = await _coinCapApi.GetAssetsAsync();

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

            //DataContext = new CurrencyViewModel(currencies);
            FirstCurrency.ItemsSource = currencies;
            SecondCurrency.ItemsSource = currencies;
        }

        private void Currency_Convert(object sender, RoutedEventArgs e) 
        {
            first_value.Text = FirstCurrency?.SelectedValue?.ToString() ?? String.Empty;
            second_value.Text = SecondCurrency?.SelectedValue?.ToString() ?? String.Empty;

            decimal value = 0, first = 0, second = 0;

            try
            {
                value = Convert.ToDecimal(String.IsNullOrEmpty(Value.Text) ? "0" : Value.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            try
            {
                first = Convert.ToDecimal(String.IsNullOrEmpty(first_value.Text) ? "1" : first_value.Text.Replace('.', ','));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            try
            {
                second = Convert.ToDecimal(String.IsNullOrEmpty(second_value.Text) ? "1" : second_value.Text.Replace('.', ','));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            decimal result = 0;
            try
            {
                result = value * first / second;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
            
            Result.Text = result.ToString("F5");
        }
    }
}
