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

namespace CryptoCurrency.Pages
{
    /// <summary>
    /// Логика взаимодействия для Top.xaml
    /// </summary>
    public partial class Top : Page
    {
        public Top()
        {
            InitializeComponent();
        }        

        public Top(object dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;
        }
    }
}
